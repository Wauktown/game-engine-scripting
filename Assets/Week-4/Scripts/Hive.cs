using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hive : MonoBehaviour
{
    // Start is called before the first frame update
    public float honeyProductionRate = 5.0f; // Rate of honey production per second
    public int startingNumberOfBees = 10;
    public GameObject BeePrefab;

    private int nectar = 0;
    private int honey = 0;
    private float honeyProductionTimer = 0.0f;
    private bool isCountingDown = false;


    void Start()
    {
        // Instantiate bees
        for (int i = 0; i < startingNumberOfBees; i++)
        {
            GameObject beeObject = Instantiate(BeePrefab, transform.position, Quaternion.identity);
            Bee bee = beeObject.GetComponent<Bee>();
            bee.Init(this); // Initialize the bee with a reference to this hive
        }
    }

    void Update()
    {
        // Check if there is nectar and if the countdown is not already running
        if (nectar > 0 && !isCountingDown)
        {
            // Start counting down
            isCountingDown = true;
            honeyProductionTimer = honeyProductionRate;
        }

        // Count down to produce honey
        if (isCountingDown)
        {
            honeyProductionTimer -= Time.deltaTime;
            if (honeyProductionTimer <= 0)
            {
                ProduceHoney();
            }
        }
    }

    public bool TakeHoney()
    {
        if (honey > 0) // Check if there is honey available in the hive
        {
            honey--; // Decrease the honey count
            return true; // Return true to indicate successful honey retrieval
        }
        else
        {
            return false; // Return false if there is no honey available
        }
    }

    // Function to receive nectar from bees
    public void GiveNectar()
    {
        if (nectar > 0) // Check if there is nectar available in the hive
        {
            nectar--; // Decrease the nectar count
                      // Optionally, you can add additional behaviors here
        }
        else
        {
            // Optionally, you can add behaviors when there is no nectar available
        }
    }
    // Function to produce honey
    private void ProduceHoney()
    {
        honey++;
        nectar--;
        if (nectar > 0)
        {
            honeyProductionTimer = honeyProductionRate;
        }
        else
        {
            isCountingDown = false;
        }
    }
}