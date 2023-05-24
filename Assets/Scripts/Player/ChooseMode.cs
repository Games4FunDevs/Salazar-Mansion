using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseMode : MonoBehaviour
{
    public string texto;
    private int valor;

    void Awake()
    {
        texto = this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        if (this.gameObject.name.Contains("P1") && PlayerPrefs.HasKey("P1ModoMov"))
            { this.texto = PlayerPrefs.GetString("P1ModoMov"); }
        if (this.gameObject.name.Contains("P2") && PlayerPrefs.HasKey("P2ModoMov"))
            { this.texto = PlayerPrefs.GetString("P2ModoMov"); }
    }

    void Start() => this.GetComponent<TMPro.TMP_Dropdown>().captionText.text = this.texto;

    public void Mode(TextMeshProUGUI text)
    {
        if (this.gameObject.name.Contains("P1"))
            PlayerPrefs.SetString("P1ModoMov", text.text);
        if (this.gameObject.name.Contains("P2"))
            PlayerPrefs.SetString("P2ModoMov", text.text);
    }
}
