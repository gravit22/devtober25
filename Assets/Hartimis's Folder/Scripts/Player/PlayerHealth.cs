using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frountHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth; // Sets the health to maxHealth.
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0); // Clears the damage screen.
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0 , maxHealth);
        UpdateHealthUI();
        if(overlay.color.a  > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                // Fade Image
                float tempAlapha = overlay.color.a;
                tempAlapha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlapha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        
        healthText.text = "Health "+ health;
        float fillF = frountHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frountHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentCompleat = lerpTimer / chipSpeed;
            percentCompleat = percentCompleat * percentCompleat;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentCompleat);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentCompleat = lerpTimer / chipSpeed;
            percentCompleat = percentCompleat * percentCompleat;
            frountHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentCompleat);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }
    
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

}
