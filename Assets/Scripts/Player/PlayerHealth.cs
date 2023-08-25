using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float lerpTime;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    public Image frontHB;
    public Image backHB;
    public TextMeshProUGUI heal;

    [Header("Damage Overlay")]
    public Image damgeOverlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;
    void Start()
    {
        health = maxHealth;
        damgeOverlay.color = new Color(damgeOverlay.color.r, damgeOverlay.color.g, damgeOverlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        heal.SetText(health.ToString() + "/100");

        if(damgeOverlay.color.a > 0)
        {
            if (health < 30) return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                float tempAlpha = damgeOverlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                damgeOverlay.color = new Color(damgeOverlay.color.r, damgeOverlay.color.g, damgeOverlay.color.b, tempAlpha);
            }
        }
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
        durationTimer = 0f;
        damgeOverlay.color = new Color(damgeOverlay.color.r, damgeOverlay.color.g, damgeOverlay.color.b, 1);
    }

    public void RestoreHealth(float crossFood)
    {
        health += crossFood;
        lerpTime = 0f;
    }
}
