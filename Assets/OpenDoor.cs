using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoor : MonoBehaviour
{
    public Animation hingehere;
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
        GameManager.AddRestartEventListener(ResetDoor);
    }

    // Update is called once per frame
    void OnTriggerStay (Collider other)
    {
        if(Input.GetKey(KeyCode.E))
        hingehere.Play();
    }

    void ResetDoor()
    {
        transform.localPosition = initialLocalPosition;
        transform.localRotation = initialLocalRotation;
    }

    void OnDestroy()
    {
        GameManager.RemoveRestartEventListener(ResetDoor);
    }

}
