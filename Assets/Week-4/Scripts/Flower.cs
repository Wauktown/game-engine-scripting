using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Start is called before the first frame update
    public float nectarProductionRate = 10.0f; // Rate of nectar production per second
    public Color nectarReadyColor;
    public Color nectarNotReadyColor;

    private bool hasNectar = true; // Initially set to true to indicate nectar is ready
    private float nectarProductionTimer = 0.0f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Set initial color to indicate nectar is ready
        spriteRenderer.color = nectarReadyColor;
    }

    void Update()
    {
        // Check if the flower has nectar
        if (hasNectar)
        {
            // Count down to produce nectar
            nectarProductionTimer += Time.deltaTime;
            if (nectarProductionTimer >= nectarProductionRate)
            {
                ProduceNectar();
            }
        }
    }

    // Method to inform bees that there is nectar available
    public bool HasNectar()
    {
        return hasNectar;
    }

    public void CollectNectar()
    {
        // Reset the nectar availability
        hasNectar = false;
        // Optionally, you can add visual feedback or other behaviors when nectar is collected
    }

    // Method to allow bees to take nectar
    public bool TakeNectar()
    {
        if (hasNectar)
        {
            hasNectar = false; // Set to false after nectar is taken
            // Update color to indicate nectar is not ready
            spriteRenderer.color = nectarNotReadyColor;
            nectarProductionTimer = 0.0f; // Reset the timer
            return true;
        }
        else
        {
            return false;
        }
    }

    // Method to produce nectar
    private void ProduceNectar()
    {
        hasNectar = true;
        // Update color to indicate nectar is ready
        spriteRenderer.color = nectarReadyColor;
    }
}