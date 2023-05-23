using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseMode : MonoBehaviour
{
    public string texto;

    void Awake()
    {
        texto = this.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        if (this.gameObject.name.Contains("P1") && PlayerPrefs.HasKey("P1ModoMov"))
        {
            texto = PlayerPrefs.GetString("P1ModoMov");
        }
        if (this.gameObject.name.Contains("P2") && PlayerPrefs.HasKey("P2ModoMov"))
        {
            texto = PlayerPrefs.GetString("P2ModoMov");
        }
    }

    public void Mode(TextMeshProUGUI text)
    {
        if (this.gameObject.name.Contains("P1"))
        {
            PlayerPrefs.SetString("P1ModoMov", text.text);
            print(PlayerPrefs.GetString("P1ModoMov"));
        }
        else if (this.gameObject.name.Contains("P2"))
        {
            PlayerPrefs.SetString("P2ModoMov", text.text);
            print(PlayerPrefs.GetString("P2ModoMov"));
        }
    }
}
