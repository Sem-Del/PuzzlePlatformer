using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powers : MonoBehaviour
{
    public int currentPower = 0;
    public bool PowerDestroy;
    public float cooldownTime = 0.01f;
    private bool isCooldown = false;

    public Sprite PowerOne;
    public Sprite PowerTwo;
    public Sprite PowerThree;
    public Image powerImage;

    private bool canMoveBlocks = true;
    private bool gravityPowerOn = false;
    private bool thirdPower = true;

    private BoostPower boostPower;
    private PlayerMovement movement;

    public List<string> powersList = new List<string> { "Power1", "Power2", "Power3" };

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
        }else if (powersList[currentPower] == "Power3" && thirdPower == false) 
        { 
            ChangePower();
            Debug.Log("Power3 not unlocked switched to power " + powersList[currentPower]);
        }else if (powersList[currentPower] == "Power3" && thirdPower == true)
        {
            if (boostPower != null)
            {
                boostPower.boostPower();
            }
            else
            {
                ChangePower();
                Debug.Log("Error 42069");
            }
            
            powerImage.sprite = PowerThree;
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
