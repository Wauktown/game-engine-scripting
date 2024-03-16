using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateHealthText(100);
    }
    public void UpdateHealthText(int healthValue)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + healthValue.ToString() + "%"; // Update the health text on the UI
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
