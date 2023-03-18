using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneInicial : MonoBehaviour
{
    private Controles controles;

    public string[] textos;
    public TextMeshProUGUI text_;
    public int count = 0;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        text_ = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("ComeçouJogar") == false)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    void Update()
    {
        text_.text = textos[count];
        
        if (controles.P1.Interagir.triggered || controles.P1.Interagir.triggered)
            count++;
        
        if (count == textos.Length)
        {
            PlayerPrefs.SetString("ComeçouJogar", "true");
            Destroy(this.gameObject);
        }
    }
}
