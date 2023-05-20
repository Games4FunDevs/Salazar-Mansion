using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMinigame : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;

    public GameObject canvasMinigame, btn, col_;
    public bool p1, p2;

    void Awake()
    {
        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (canvasMinigame.activeSelf)
        {
            if (controles.P1.Fechar.triggered)
            {
                canvasMinigame.SetActive(false);
                col_.GetComponent<PlayerController>().enabled = true;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        // if (PlayerPrefs.GetString("podeQuadros") == "true")
        // {
            if ((col.CompareTag("P1") && controles.P1.Interagir.triggered && p1 == true)
                || (col.CompareTag("P2") && controles.P2.Interagir.triggered && p2 == true))
            {
                canvasMinigame.SetActive(true);
                col_ = col.gameObject;
                // btn.GetComponent<quadros_cores>().ChangeColor(0);
                col.transform.GetChild(1).gameObject.GetComponent<Animator>().SetInteger("state", 0);
                col.GetComponent<PlayerController>().enabled = false;
            }
        // }
    }
}
