using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Billboeard : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;
    
    public GameObject billboardUI1, billboardUI2;

    void Awake()
    {
        billboardUI1 = GameObject.Find("BillboardUI1");
        billboardUI2 = GameObject.Find("BillboardUI2");

        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

    void Start() 
    {
        billboardUI1.SetActive(false);
        billboardUI2.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("P1") && controles.P1.Interagir.triggered)
        {
            billboardUI1.SetActive(false);
        }
        
        if (col.CompareTag("P2") && controles.P2.Interagir.triggered)
        {
            billboardUI2.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("P1"))
        {
            billboardUI1.SetActive(true);
        }
        
        if (col.CompareTag("P2"))
        {
            billboardUI2.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("P1"))
        {
            billboardUI1.SetActive(false);
        }
        
        if (col.CompareTag("P2"))
        {
            billboardUI2.SetActive(false);
        }
    }
}
