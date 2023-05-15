using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class QuickTime : MonoBehaviour
{
    public GameObject img, gunshot;
    public Animator salazar;
    public TextMeshProUGUI text_;
    public string[] botao;
    public string resposta;
    public bool open = false, corout;
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
        if (qtd == 3 && acerto[0] && acerto[1] && acerto[2] && this.gameObject.name.Contains("P1"))
        {
            PlayerPrefs.SetString("P1QT", "true");
        }
        if (qtd == 3 && acerto[0] && acerto[1] && acerto[2] && this.gameObject.name.Contains("P1"))
        {
            PlayerPrefs.SetString("P2QT", "true");
        }

        if (PlayerPrefs.GetString("ArmaPlayerP1") == "true" && PlayerPrefs.GetString("ArmaPlayerP2") == "true" 
            && ((qtd == 1 && !acerto[0]) || (qtd == 2 && !acerto[1]) || (qtd == 3 && !acerto[2]))) // fez 1 erro
        {
            Reset();
        }

        if (PlayerPrefs.GetString("P2QT") == "true" && PlayerPrefs.GetString("P1QT") == "true") 
        {
            PlayerPrefs.SetString("EndGame", "true");
            SceneManager.LoadScene("Menu");
        }

        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
        else
        {
            if (corout == false)
            {
                this.GetComponent<moveBoss>().enabled = true;
                resposta = botao[Random.Range(0, 3)];
                salazar.SetLayerWeight(1, 0);
                StartCoroutine("Shoot", 1f);
                corout = true;
            }
            
            if (open == true)
            {

                if (this.gameObject.name.Contains("P1"))
                {
                    switch(resposta)
                    {
                        case "a":
                            if (controles.P1.A.triggered) { Acerto(); }
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

    void Reset()
    {
        PlayerPrefs.SetString("P1QT", "false");
        PlayerPrefs.SetString("P2QT", "false");
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Shoot()
    {
        this.open = true;
        img.SetActive(true);
        text_.text = resposta;
        yield return new WaitForSeconds(1f);
        img.SetActive(false);
        curTime = timer;
        this.open = false;
        qtd++;
        this.corout = false;
    }

    void Acerto() 
    { 
        this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetLayerWeight(1, 0.7f);
        salazar.SetLayerWeight(1, 0.5f);
        salazar.SetTrigger("trigger");
        StartCoroutine("Gunshot", .1f);
        this.acerto[qtd] = true; 
        this.img.SetActive(false);
    }

    IEnumerator Gunshot()
    {
        gunshot.SetActive(true);
        yield return new WaitForSeconds(.1f);
        this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetLayerWeight(1, 0);
        gunshot.SetActive(false);
    }
}
