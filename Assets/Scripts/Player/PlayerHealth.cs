using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTime;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    public Image frontHB;
    public Image backHB;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDame(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            RestoreHealth(Random.Range(20, 50));
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHB.fillAmount;
        float fillB = backHB.fillAmount;
        float hFraction = health / maxHealth;

        if(fillB > hFraction)
        {
            frontHB.fillAmount = hFraction;
            backHB.color = Color.red;
            lerpTime += Time.deltaTime;

            float percentComplate = lerpTime / chipSpeed;
            percentComplate *= percentComplate * percentComplate;
            backHB.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplate);

        }

        
        if(fillF < hFraction)
        {
            backHB.fillAmount = hFraction;
            backHB.color = Color.green;
            lerpTime += Time.deltaTime;

            float percentComplete = lerpTime / chipSpeed;
            frontHB.fillAmount = Mathf.Lerp(fillF, backHB.fillAmount, percentComplete);
        }
        

    }

    public void TakeDame(float damage)
    {
        health -= damage;
        lerpTime = 0f;
    }

    public void RestoreHealth(float crossFood)
    {
        health += crossFood;
        lerpTime = 0f;
    }
}
