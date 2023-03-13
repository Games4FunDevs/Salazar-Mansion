using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesAcionaveis1 : MonoBehaviour
{
    public bool status;
    private float timer = .5f, ctime; 

    private Controles controles;
    private Vector2 inputs;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (this.status)
            this.ctime -= Time.deltaTime;

        if (this.ctime <= 0)
        {
            this.ctime = 0;
            this.status = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)) 
        {
            this.status = true;
            this.ctime = timer;
        }
    }
}
