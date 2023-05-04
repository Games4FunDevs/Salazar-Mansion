using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboeard : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;

    private Camera cam;

    void Awake()
    {
        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && controles.P1.Interagir.triggered) || (col.CompareTag("P2") && controles.P2.Interagir.triggered))
        {
            this.transform.GetChild(0).GetComponent<Image>().enabled = false;
            if (this.transform.childCount > 1)
                this.transform.GetChild(1).GetComponent<Image>().enabled = false;
        }

        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            this.transform.GetChild(0).gameObject.transform.LookAt(this.cam.transform.position, Vector3.up);
            if (this.transform.childCount > 1)
                this.transform.GetChild(1).gameObject.transform.LookAt(this.cam.transform.position, Vector3.up);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            this.cam = col.transform.GetChild(2).GetComponent<Camera>();
            this.transform.GetChild(0).GetComponent<Image>().enabled = true;
            if (this.transform.childCount > 1)
                this.transform.GetChild(1).GetComponent<Image>().enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            this.transform.GetChild(0).GetComponent<Image>().enabled = false;
            if (this.transform.childCount > 1)
                this.transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }
}
