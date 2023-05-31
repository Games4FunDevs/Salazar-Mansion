using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CutsceneInicial : MonoBehaviour
{
    private Controles controles;

    public GameObject cinematica, cinematica2, gameover, btnGO;

    public string[] textos;
    public TextMeshProUGUI text_;
    public int count = 0;
    
    public float timer = 60f, curTime, timerStart = 0;
    public GameObject portaP2, painel, sufocado;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        text_ = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("ComeçouJogar") == false)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            PlayerPrefs.SetString("ComeçouJogar", "false");
        }

        curTime = timer;
    }

    void Update()
    {
        if (controles.Any.AnyKey.triggered)
            count++;
        
        if (count > textos.Length)
        {
            if (!cinematica2.activeSelf && !cinematica.activeSelf && timerStart == 1)
            {
                timerStart = 2;
            }
        }
        else if (count == textos.Length)
        {
            PlayerPrefs.SetString("ComeçouJogar", "true");
            PlayerPrefs.SetString("podeAndar", "true");
            PlayerPrefs.SetString("ShowBtnInfo1", "true");
            if (cinematica != null) { cinematica.SetActive(true); }
            timerStart = 1;
            painel.SetActive(false);
            sufocado.SetActive(true);
            count++;
        }
        else if (count < textos.Length)
        {
            text_.text = textos[count];
        }

        if (timerStart == 2)
        {
            curTime -= Time.deltaTime * Time.timeScale;
            sufocado.GetComponent<Image>().color += new Color(0f, 0f, 0f, ((1/curTime)/100));  
        }

        if (curTime <= 0)
        {
            gameover.SetActive(true);
            EventSystem.current.SetSelectedGameObject(btnGO);
            sufocado.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            curTime = 60;
            timerStart = 0;
            count = 0;
        }
        else
        {
            if (portaP2 != null && portaP2.GetComponent<OpenDoon>().unlocked == true )
                Destroy(this.gameObject);
        }
    }

    public void SetTimer60() => curTime = timer;
}
