using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.AddRestartEventListener(ResetState);

    }

    // Update is called once per frame
   private void OnDestroy()
    {
        GameManager.RemoveRestartEventListener(ResetState);
    }

    private void ResetState()
    {
        gameObject.SetActive(true);
    }
}
