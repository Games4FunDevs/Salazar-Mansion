using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUnlock : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)) 
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.GetComponent<Animator>().Play("alavanca", 0, 0);
            this.gameObject.GetComponent<EnergyUnlock>().enabled = false;
        }
    }
}
