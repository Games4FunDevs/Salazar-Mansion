using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoon : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false;
    public Animator anim;

    private bool openTrigger, closeTrigger;
    public string openDoor = "OpenDoor1", closeDoor = "CloseDoor1";
    public GameObject other;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2")) 
        {
            if (col.gameObject.GetComponent<PlayerController>().hasKey == true)
            {
                this.unlocked = true;
                other.GetComponent<OpenDoon>().unlocked = true;
            }
        }

        if (this.unlocked == true && (col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)
            && this.openTrigger)
        {
            this.anim.Play(openDoor, 0, 0);
            this.other.GetComponent<OpenDoon>().closeTrigger = true;
            this.openTrigger = false;
        }
    }

    void OnTriggerExit(Collider col) 
    {
        if ((col.CompareTag("P1") || col.CompareTag("P2")) && closeTrigger)
        {
            anim.Play(closeDoor, 0, 0);
            this.other.GetComponent<OpenDoon>().openTrigger = true;
            closeTrigger = false;
        }
    }
}
