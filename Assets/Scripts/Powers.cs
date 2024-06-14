using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powers : MonoBehaviour
{
    public int currentPower = 0;
    public bool PowerDestroy;
    private float cooldownTime = 0.2f;
    private bool isCooldown = false;

    public Sprite PowerOne;
    public Sprite PowerTwo;
    public Sprite PowerThree;
    public Image powerImage;

    private bool canMoveBlocks = true;
    private bool attackPower = false;

    private PlayerMovement movement;

    public GameObject laserPrefab;
    public Transform firePoint;

    public List<string> powersList = new List<string> { "Power1", "Power2", "Power3" };

    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (isCooldown)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F) && movement.powerSystemUnlocked == true)
        {
            StartCoroutine(StartCooldown());
            ChangePower();
        }

        if (Input.GetKeyDown(KeyCode.R) && powersList[currentPower] == "Power3" && attackPower)
        {
            ShootLaser();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Object") && PowerDestroy == true && canMoveBlocks)
        {
            Destroy(other.gameObject);
        }
    }

    private void HandleMovePowerBlocks()
    {
        GameObject[] movePowerBlocks = GameObject.FindGameObjectsWithTag("MovePower");

        foreach (GameObject block in movePowerBlocks)
        {
            Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * 1f;

                rb.constraints = canMoveBlocks ? RigidbodyConstraints2D.None : RigidbodyConstraints2D.FreezeAll;
                rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    public void ChangePower()
    {
        currentPower = (currentPower + 1) % powersList.Count;

        Debug.Log("Switched to " + powersList[currentPower] + " (Power " + (currentPower + 1) + ")");
        UsePower(powersList[currentPower]);

        if (powersList[currentPower] == "Power1")
        {
            canMoveBlocks = true;
            powerImage.sprite = PowerOne;
        }
        else if (powersList[currentPower] == "Power2")
        {
            canMoveBlocks = false;
            powerImage.sprite = PowerTwo;
        }
        else if (powersList[currentPower] == "Power3" && attackPower == false)
        {
            ChangePower();
        }
        else if (powersList[currentPower] == "Power3" && attackPower == true)
        {
            powerImage.sprite = PowerThree;
        }

        HandleMovePowerBlocks();
    }

    void UsePower(string power)
    {
        switch (power)
        {
            case "Power1":
                break;
            case "Power2":
                break;
            case "Power3":
                attackPower = true;
                break;
            default:
                break;
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }

    void ShootLaser()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}
