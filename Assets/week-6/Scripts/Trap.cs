using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week6
{
    public class Trap : MonoBehaviour
    {

        public int damageAmount = 10;

        // Called when a collider enters the trigger zone of the trap
        private void OnTriggerEnter(Collider other)
        {
            // Check if the collider belongs to the player
            if (other.CompareTag("Player"))
            {
                // Access the PlayerController component of the player object
                PlayerController playerController = other.GetComponent<PlayerController>();

                // Check if the PlayerController component is not null
                if (playerController != null)
                {
                    // Call the TakeDamage method of the playerController with the specified damageAmount
                    playerController.TakeDamage(damageAmount);
                }
            }
        }
    }
}

