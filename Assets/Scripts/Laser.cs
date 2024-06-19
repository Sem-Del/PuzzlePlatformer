using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        InitializeLineRenderer();
    }

    private void InitializeLineRenderer()
    {
        if (m_lineRenderer == null)
        {
            Debug.LogError("LineRenderer is not assigned in the inspector.");
            return;
        }

        m_lineRenderer.positionCount = 2; // Correctly set the position count
        m_lineRenderer.SetPosition(0, Vector3.zero); // Initialize start position
        m_lineRenderer.SetPosition(1, Vector3.forward * defDistanceRay); // Initialize end position
    }

    // Method to activate the laser and remove it after 0.3 seconds, then wait 2 seconds before it can be activated again
    public void ActivateLaser()
    {
        StartCoroutine(LaserActivationSequence());
    }

    IEnumerator LaserActivationSequence()
    {
        ShootLaser();

        // Wait 0.3 seconds before removing the laser
        yield return new WaitForSeconds(0.3f);

        // Check if positions are set before trying to remove them
        if (m_lineRenderer.positionCount > 0)
        {
            // Remove the laser
            m_lineRenderer.positionCount = 0;
        }

        // Wait 2 seconds before the laser can be activated again
        yield return new WaitForSeconds(2f);
    }

    void ShootLaser()
    {
        if (m_lineRenderer.positionCount != 2)
        {
            m_lineRenderer.positionCount = 2; // Ensure the position count is set to 2 before setting positions
        }

        RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);

        if (hit)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                BossBattle enemy = hit.collider.GetComponent<BossBattle>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1); // Adjust the damage value as needed
                }
            }
            Draw2DRay(laserFirePoint.position, hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
