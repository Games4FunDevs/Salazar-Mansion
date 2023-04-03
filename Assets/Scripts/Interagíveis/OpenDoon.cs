using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoon : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false, canOpen = false;
    public Animator anim;

    public bool openTrigger, closeTrigger;
    public string openDoor = "OpenDoor1", closeDoor = "CloseDoor1";
    public GameObject other;

    public AudioClip[] sons;
    AudioSource audio_;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        audio_ = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider col)
    {
        if (!this.unlocked && ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || 
            (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)))
        {
            if (col.gameObject.GetComponent<PlayerController>().hasKey == true)
            {
                this.unlocked = true;
                other.GetComponent<OpenDoon>().unlocked = true;
                StartCoroutine("Unlock", 0.3f);
            }
        }
        
        if (this.unlocked == true)
        {
            if (canOpen == true && ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || 
            (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1))
            && this.openTrigger)
            {
                this.anim.Play(openDoor, 0, 0);
                GetComponent<AudioSource>().clip = sons[0];
                GetComponent<AudioSource>().Play();
                this.other.GetComponent<OpenDoon>().closeTrigger = true;
                this.openTrigger = false;
            }
        }
        

        if (col.CompareTag("Inimigo") && this.openTrigger)
        {
            this.anim.Play(openDoor, 0, 0);
            GetComponent<AudioSource>().clip = sons[0];
            GetComponent<AudioSource>().Play();
            this.other.GetComponent<OpenDoon>().closeTrigger = true;
            this.openTrigger = false;
        }
    }

    void OnTriggerExit(Collider col) 
    {
        if ((col.CompareTag("P1") || col.CompareTag("P2")) && closeTrigger)
        {
            anim.Play(closeDoor, 0, 0);
            audio_.clip = sons[1];
            audio_.Play();
            this.other.GetComponent<OpenDoon>().openTrigger = true;
            closeTrigger = false;
        }
    }

    IEnumerator Unlock()
    {
        yield return new WaitForSeconds(.3f);
        this.canOpen = true;
    }
}
