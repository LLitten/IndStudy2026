using System.Reflection;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;


public class HealthBarController : MonoBehaviour
{
    //Declare variables
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Gradient healthGradient;
    private float targetFillAmount = 1f;
    [SerializeField] private float lerpSpeed = 5f;

    //Health bar sliding
    public void UpdateHealthBar()

    {
        targetFillAmount = currentHealth / maxHealth;


    } //close UpdateHealthBar

    public void TakeDamage (float damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        UpdateHealthBar();
    } //close TakeDamage

    public void HealDamage(float healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        UpdateHealthBar() ;
    } //close HealDamage


    void Update()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, targetFillAmount, Time.deltaTime * lerpSpeed);

            healthBarImage.color = healthGradient.Evaluate(healthBarImage.fillAmount);
        }
        if (healthText != null)
        {
            float displayHealth = healthBarImage.fillAmount * maxHealth;
            healthText.text = $"{Mathf.RoundToInt(displayHealth)} / {Mathf.RoundToInt(maxHealth)}";

        }
    }



} //close HealthBarController
