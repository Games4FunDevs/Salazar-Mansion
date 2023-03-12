using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoon : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false;
    // private Animator anim;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
        // anim = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2")) 
        {
            if (col.gameObject.GetComponent<PlayerController>().hasKey)
                this.unlocked = true;

            if (unlocked && (controles.P1.Interagir.ReadValue<float>() == 1 || controles.P2.Interagir.ReadValue<float>() == 1))
            {
                this.gameObject.SetActive(false); // anim
                col.gameObject.GetComponent<PlayerController>().hasKey = false;
            }
        }
    }
}
