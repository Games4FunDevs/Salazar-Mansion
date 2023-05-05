using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMinigame : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;

    public GameObject canvasMinigame;
    public bool p1, p2;

    void Awake()
    {
        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        // if (PlayerPrefs.GetString("podeQuadros") == "true")
        // {
            if ((col.CompareTag("P1") && controles.P1.Interagir.triggered && p1 == true) 
                || (col.CompareTag("P2") && controles.P2.Interagir.triggered && p2 == true))
            {
                canvasMinigame.SetActive(true);
                col.GetComponent<PlayerController>().enabled = false; 
            }
        // }

        if ((col.CompareTag("P1") || col.CompareTag("P2")) && controles.P1.Fechar.triggered && canvasMinigame.activeSelf == true)
        {
            canvasMinigame.SetActive(false);
            col.GetComponent<PlayerController>().enabled = true;
        }
    }
}
