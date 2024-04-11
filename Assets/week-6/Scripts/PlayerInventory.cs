using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfDiamonds { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    private void Start()
    {
        GameManager.AddRestartEventListener(ResetInventory);
         ResetInventory();
    }

    private void OnDestroy()
    {
        GameManager.RemoveRestartEventListener(ResetInventory);
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollected.Invoke(this);
    }
    private void ResetInventory()
    {
        NumberOfDiamonds = 0;
    }
}
