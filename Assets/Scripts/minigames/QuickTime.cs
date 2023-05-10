using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuickTime : MonoBehaviour
{
    public GameObject img;
    public string[] botao;
    public string resposta;
    public bool open = false;
    public bool[] acerto; 
    public int qtd = 0;
    public float timer = 2f, curTime = 0;

    private Controles controles;

    void Start()
    {
        curTime = timer;

        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (qtd == 3)
        {
            print("cabou");
        }

        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
        else
        {
            StartCoroutine("Shoot", 1f);
            if (open == true)
            {
                if (this.gameObject.name.Contains("P1"))
                {
                    switch(resposta)
                    {
                        case "a":
                            if (controles.P1.A.triggered) Acerto();
                            break;
                        case "s":
                            if (controles.P1.S.triggered) Acerto();
                            break;
                        case "d":
                            if (controles.P1.D.triggered) Acerto();
                            break;
                    }
                }
                if (this.gameObject.name.Contains("P2"))
                {
                    switch(resposta)
                    {
                        case "j":
                            if (controles.P2.J.triggered) Acerto(); 
                            break;
                        case "k":
                            if (controles.P2.K.triggered) Acerto(); 
                            break;
                        case "l":
                            if (controles.P2.L.triggered) Acerto();
                            break;
                    }
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        open = true;
        img.SetActive(true);
        resposta = botao[Random.Range(0, 4)];
        img.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = resposta;
        yield return new WaitForSeconds(1f);
        img.SetActive(false);
        curTime = timer;
        open = false;
        qtd++;
    }

    void Acerto() { this.acerto[qtd] = true; }
}
