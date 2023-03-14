using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoCut : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
