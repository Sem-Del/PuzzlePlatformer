using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int hp = 5;
    public GameObject launchBlock;
    public GameObject currentBoss;

    void Start()
    {
        launchBlock.SetActive(false);
        currentBoss.SetActive(true);
    }

    void Update()
    {
        if (hp <= 0)
        {
            defeated();
        }
    }

    void defeated()
    {
        Debug.Log("The boss is defeated!");
        launchBlock.SetActive(true);
        currentBoss.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Boss took damage, current hp: " + hp);
    }
}
