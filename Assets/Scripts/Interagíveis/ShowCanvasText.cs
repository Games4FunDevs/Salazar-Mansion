using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCanvasText : MonoBehaviour
{
    public GameObject[] gObject;
    public string texto;
    private int player = 0;
    public bool showing, auto, cAuto;

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
            {
                gObject[0].SetActive(true);
                gObject[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = texto;

                if (controles.P1.Interagir.triggered)
                {
                    showing = false;
                    this.cAuto = false;
                    gObject[0].SetActive(false);
                    StartCoroutine("ShowCollider", 0.15f);
                }
            } 
            if (player == 2)
            {
                gObject[1].SetActive(true);
                gObject[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = texto;

                if (controles.P2.Interagir.triggered)
                {
                    showing = false;
                    this.cAuto = false;
                    gObject[1].SetActive(false);
                    StartCoroutine("ShowCollider", 0.15f);
                }
            }
        }
        // else
        // {
        //     if (player == 1)
                
        //     if (player == 2)
                
        // }
    }
 
    void OnTriggerStay(Collider col)
    {
        if (this.auto && this.cAuto)
        {
            this.showing = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (!this.auto)
        {
            if ((col.CompareTag("P1") && controles.P1.Interagir.triggered) || (col.CompareTag("P2") && controles.P2.Interagir.triggered))
            {
                this.showing = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (col.CompareTag("P1")) 
            player = 1;
        else if (col.CompareTag("P2"))
            player = 2;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerController>().hasKey && this.gameObject.name == "DescItem Tranca" ||
            this.gameObject.name == "DescItem Tranca 1" && GameObject.Find("door (5)").transform.GetChild(0).GetComponent<OpenDoon>().unlocked)
            Destroy(this.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        if ((col.CompareTag("P1") || col.CompareTag("P2")))
        {
            if (!this.cAuto && this.auto)
                this.cAuto = true;
        }
    }

    IEnumerator ShowCollider()
    {
        yield return new WaitForSeconds(.15f);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
