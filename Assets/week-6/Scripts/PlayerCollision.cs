using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger area is the game over collider
        if (other.CompareTag("Player"))
        {
            // Trigger the game-over event
            GameManager.instance.GameOver();
        }
    }
}
