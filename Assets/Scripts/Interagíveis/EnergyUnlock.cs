using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUnlock : MonoBehaviour
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
            if (controles.P1.Interagir.ReadValue<float>() == 1 || controles.P2.Interagir.ReadValue<float>() == 1)
            {
                Destroy(this.transform.GetChild(0).gameObject);
            }
        }
    }
}
