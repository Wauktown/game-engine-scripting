using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private int initialHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateHealthText(initialHealth);
        GameManager.AddRestartEventListener(ResetHealthUI);
    }
    public void UpdateHealthText(int healthValue)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + healthValue.ToString() + "%"; // Update the health text on the UI
        }
    }

    private void ResetHealthUI()
    {
        UpdateHealthText(initialHealth); // Reset health text to initial value
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
