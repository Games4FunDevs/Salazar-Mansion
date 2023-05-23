using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class QuickTime : MonoBehaviour
{
    public GameObject imgp1, gunshotp1, imgp2, gunshotp2, p1, p2, cutscFim; 
    public Animator salazar;
    public TextMeshProUGUI txtp1, txtp2;
    public string[] botaop1, botaop2;
    public string respostap1, respostap2;
    public bool open = false, corout, p1ganhou, p2ganhou;
    public bool[] acertop1, acertop2; 
    public int qtd = 0;
    public float timer = 2f, curTime = 0;

    private Controles controles;

    void Awake()
    {
        curTime = timer;

        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (qtd == 3) { Ganhou(); }

        // fez 1 erro
        if ((qtd == 1 && (!acertop1[0] || !acertop2[0])) || (qtd == 2 && (!acertop1[1] || !acertop2[1]) || (qtd == 3 && (!acertop1[2] || !acertop2[2])))) 
        {
            Reset();
        }

        QuickTimeEvent();
    }

    void QuickTimeEvent()
    {
        if (curTime > 0)
        {
            curTime -= Time.deltaTime * Time.timeScale;
        }
        else
        {
            if (corout == false)
            {
                respostap1 = botaop1[Random.Range(0, 3)];
                respostap2 = botaop2[Random.Range(0, 3)];
                salazar.SetLayerWeight(1, 0);
                StartCoroutine("Shoot", 1f);
                corout = true;
            }
            
            if (this.open == true)
            {
                if (respostap1 == "A" && controles.P1.A.triggered || respostap1 == "S" && controles.P1.S.triggered || respostap1 == "D" && controles.P1.D.triggered) 
                { 
                    Acerto(p1, acertop1, imgp1, gunshotp1); 
                }
                if (respostap2 == "Left" && controles.P2.Left.triggered || respostap2 == "Down" && controles.P2.Down.triggered || respostap2 == "Right" && controles.P2.Right.triggered) 
                { 
                    Acerto(p2, acertop2, imgp2, gunshotp2); 
                }
            }
        }
    }

    void Reset()
    {
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Shoot()
    {
        open = true;
        imgp1.SetActive(true);
        imgp2.SetActive(true);
        txtp1.text = respostap1;
        txtp2.text = respostap2;
        yield return new WaitForSeconds(1f);
        imgp1.SetActive(false);
        imgp2.SetActive(false);
        curTime = timer;
        open = false;
        qtd++;
        corout = false;
    }

    void Acerto(GameObject player, bool[] acerto, GameObject img_, GameObject gunshot) 
    { 
        player.transform.GetChild(0).gameObject.GetComponent<Animator>().SetLayerWeight(1, 0.7f);
        salazar.SetLayerWeight(1, 0.5f);
        salazar.SetTrigger("trigger");
        StartCoroutine(Gunshot(gunshot, player));
        acerto[qtd] = true; 
        img_.SetActive(false);
    }

    IEnumerator Gunshot(GameObject gunshot, GameObject player)
    {
        gunshot.SetActive(true);
        yield return new WaitForSeconds(.1f);
        player.transform.GetChild(0).gameObject.GetComponent<Animator>().SetLayerWeight(1, 0);
        gunshot.SetActive(false);
    }

    void Ganhou()
    {
        if (acertop1[0] && acertop1[1] && acertop1[2])
        {
            p1ganhou = true;
        }

        if (acertop2[0] && acertop2[1] && acertop2[2])
        {
            p2ganhou = true;
        }

        if (p1ganhou == true && p2ganhou == true) 
        {
            PlayerPrefs.SetString("EndGame", "true");
            cutscFim.SetActive(true);
        }
    }
}
