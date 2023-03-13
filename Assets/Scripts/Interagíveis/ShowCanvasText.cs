using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasText : MonoBehaviour
{
    public GameObject[] gObject;
    private int player = 0;
    public bool showing = false;

    private Controles controles;
    private Vector2 inputs;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (showing)
        {
            if (player == 1)
                gObject[0].SetActive(true);
            else if (player == 2)
                gObject[1].SetActive(true);
        }
        else
        {
            if (player == 1)
                gObject[0].SetActive(false);
            else if (player == 2)
                gObject[1].SetActive(false);
        }
    }
 
    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && controles.P1.Interagir.triggered) || (col.CompareTag("P2") && controles.P2.Interagir.triggered))
            showing = !showing;

        if (col.CompareTag("P1")) 
            player = 1;
        else if (col.CompareTag("P2"))
            player = 2;
    }
}
