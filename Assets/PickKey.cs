using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public Component doorcolliderhere;
    public GameObject keygone;
    private Vector3 initialPosition;
    private bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        GameManager.AddRestartEventListener(ResetKey);
    }

    // Update is called once per frame
    void OnTriggerStay ()
    {
        if(Input.GetKey(KeyCode.E))
        doorcolliderhere.GetComponent<BoxCollider>().enabled = true;

        if (Input.GetKey(KeyCode.E))
            keygone.SetActive(false);
    }
    void ResetKey()
    {
        pickedUp = false;
        keygone.SetActive(true);
        transform.position = initialPosition;
    }
    void OnDestroy()
    {
        GameManager.RemoveRestartEventListener(ResetKey);
    }
}
