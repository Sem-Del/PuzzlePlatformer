using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public int currentPower = 0;
    public bool PowerDestroy;
    public float cooldownTime = 1f;
    private bool isCooldown = false;

    private bool canMoveBlocks = true;

    public List<string> powersList = new List<string> { "Power1", "Power2" }; // Updated to have only 2 powers

    void Update()
    {
        if (isCooldown)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(StartCooldown());
            ChangePower();
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
                rb.constraints = canMoveBlocks ? RigidbodyConstraints2D.None : RigidbodyConstraints2D.FreezeAll;
                rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    void ChangePower()
    {
        currentPower = (currentPower + 1) % powersList.Count;

        Debug.Log("Switched to " + powersList[currentPower] + " (Power " + (currentPower + 1) + ")");
        UsePower(powersList[currentPower]);

        if (powersList[currentPower] == "Power1")
        {
            canMoveBlocks = true;
        }
        else if (powersList[currentPower] == "Power2")
        {
            canMoveBlocks = false;
        }

        HandleMovePowerBlocks();
    }

    void UsePower(string power)
    {
        switch (power)
        {
            case "Power1":
                Debug.Log("Using Power1");
                break;
            case "Power2":
                Debug.Log("Using Power2");
                break;
            default:
                Debug.Log("Invalid Power");
                break;
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
