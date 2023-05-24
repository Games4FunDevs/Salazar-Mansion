using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseMode : MonoBehaviour
{
    public string texto;
    public GameObject player;

    void Awake()
    {
        texto = this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        if (this.gameObject.name.Contains("P1") && PlayerPrefs.HasKey("P1ModoMov"))
        { 
            this.texto = PlayerPrefs.GetString("P1ModoMov"); 
            this.player = GameObject.FindWithTag("P1");
        }
        if (this.gameObject.name.Contains("P2") && PlayerPrefs.HasKey("P2ModoMov"))
        { 
            this.texto = PlayerPrefs.GetString("P2ModoMov"); 
            this.player = GameObject.FindWithTag("P2");
        }
    }

    void Start()
    {
        this.GetComponent<TMPro.TMP_Dropdown>().captionText.text = this.texto;
        this.GetComponent<TMPro.TMP_Dropdown>().value = this.GetComponent<TMPro.TMP_Dropdown>().options.FindIndex(option => option.text == this.texto);
    }

    public void Mode(TextMeshProUGUI text)
    {
        if (this.gameObject.name.Contains("P1"))
            { PlayerPrefs.SetString("P1ModoMov", text.text); }
            
        if (this.gameObject.name.Contains("P2"))
            { PlayerPrefs.SetString("P2ModoMov", text.text); }

        this.player.GetComponent<PlayerController>().modoMov = text.text;
    }
}
