using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCanvasText : MonoBehaviour
{
    public GameObject[] gObject;
	public Sprite imageInspect;
    public string texto;
    private int player = 0;
    public bool showing, auto, cAuto, image, aux;

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
                if (image == false && this.aux == false)
                {
                    gObject[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = texto;
                    this.aux = true;
                }
                
                if (image == true)
                {
                    gObject[0].transform.GetChild(1).GetComponent<Image>().sprite = imageInspect;
                    gObject[0].transform.gameObject.GetComponent<Image>().enabled = false;
                    gObject[0].transform.GetChild(0).gameObject.SetActive(false);
                    gObject[0].transform.GetChild(1).gameObject.SetActive(true);
                }

                if (controles.P1.Interagir.triggered)
                {
                    this.showing = false;
                    this.cAuto = false;
                    this.aux = false;
                    gObject[0].SetActive(false);
                    if (this.gameObject.name.Contains("Billboard-minigame (1)") || this.gameObject.name.Contains("Billboard-minigame"))
                    {
			            this.gameObject.GetComponent<ShowCanvasText>().enabled = false;
                    }
                    else
                        StartCoroutine("ShowCollider", 0.15f);
                }
            } 
            if (player == 2)
            {
                gObject[1].SetActive(true);
                if (image == false && this.aux == false)
                {
                    gObject[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = texto;
                    this.aux = true;
                }
                
                if (image == true)
                {
                    gObject[1].transform.GetChild(1).GetComponent<Image>().sprite = imageInspect;
                    gObject[1].transform.gameObject.GetComponent<Image>().enabled = false;
                    gObject[1].transform.GetChild(0).gameObject.SetActive(false);
                    gObject[1].transform.GetChild(1).gameObject.SetActive(true);
                }

                if (controles.P2.Interagir.triggered)
                {
                    this.showing = false;
                    this.cAuto = false;
                    this.aux = false;
                    gObject[1].SetActive(false);
                    if (this.gameObject.name.Contains("Billboard-minigame (1)") || this.gameObject.name.Contains("Billboard-minigame"))
                    {
                        this.gameObject.GetComponent<ShowCanvasText>().enabled = false;
                    } 
                    else
                        StartCoroutine("ShowCollider", 0.15f);
                }
            }
        }

        if (this.gameObject.name == "DescItem Tranca 1" && GameObject.Find("door (5)").transform.GetChild(0).GetComponent<OpenDoon>().unlocked)
        {
           CloseText();
        }
    }
 
    void OnTriggerStay(Collider col)
    {
        if (this.auto && this.cAuto && (col.CompareTag("P1") || col.CompareTag("P2")))
        {
            this.showing = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (!this.auto)
        {
            if ((col.CompareTag("P1") && controles.P1.Interagir.triggered) || (col.CompareTag("P2") && controles.P2.Interagir.triggered))
            {
                this.showing = true;
                if (!this.gameObject.name.Contains("Billboard-minigame (1)") && !this.gameObject.name.Contains("Billboard-minigame"))
                {
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

        if (col.CompareTag("P1")) 
            this.player = 1;
        else if (col.CompareTag("P2"))
            this.player = 2;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            if (col.GetComponent<PlayerController>().hasKey1 && this.gameObject.name == "DescItem Tranca") 
            {
                CloseText();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            if (!this.cAuto && this.auto)
                this.cAuto = true;

            if (this.gameObject.name.Contains("Billboard-minigame (1)") || this.gameObject.name.Contains("Billboard-minigame"))
            {
                this.showing = false;
                this.gameObject.GetComponent<ShowCanvasText>().enabled = true;
            }

            this.aux = false;
        }
    }

    public void CloseText()
    {
        this.showing = false;
        this.cAuto = false;
        gObject[0].SetActive(false);
        gObject[1].SetActive(false);
        this.aux = false;
        StartCoroutine("ShowCollider", 0.15f);
        Destroy(this.gameObject);
    }

    IEnumerator ShowCollider()
    {
        yield return new WaitForSeconds(.15f);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
