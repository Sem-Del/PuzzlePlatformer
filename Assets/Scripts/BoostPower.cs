using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPower : MonoBehaviour
{

    private float newGravityScale = -1f;
    private float duration = 0.9f;
    private bool isActive = false;
    private Rigidbody2D rb;

    private Powers powers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void boostPower()
    {
        rb.gravityScale = newGravityScale;
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        isActive = true;
        yield return new WaitForSeconds(duration);
        rb.gravityScale = Mathf.Abs(rb.gravityScale);
        powers.ChangePower();
        isActive = false;
    }    

    void Update()
    {
        
    }
}
