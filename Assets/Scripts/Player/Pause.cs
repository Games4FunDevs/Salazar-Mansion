using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public bool inv = false, open = false;
    public GameObject canvasMenu, gameover;
    private Controles controles;

    void Awake() 
    {
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        ShowMenu();
    }

    public void CloseMenu()
    {
        inv = false;
    }
    
    void ShowMenu()
    {
        if (controles.P1.Menu.triggered) { inv = !inv; }

        if (inv == true)
        { 
            this.canvasMenu.SetActive(true);
            if (open == false) 
            {
                EventSystem.current.SetSelectedGameObject(canvasMenu.transform.GetChild(1).transform.GetChild(0).gameObject);
                open = true;
            }
        }

        if (inv == false)
        { 
            canvasMenu.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            canvasMenu.transform.GetChild(1).gameObject.SetActive(true);
            canvasMenu.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            canvasMenu.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
            canvasMenu.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(true);
            canvasMenu.transform.GetChild(2).gameObject.SetActive(false);
            canvasMenu.transform.GetChild(3).gameObject.SetActive(false);
            canvasMenu.transform.GetChild(4).gameObject.SetActive(false);
            canvasMenu.transform.GetChild(5).gameObject.SetActive(false);
            this.canvasMenu.SetActive(false); 
            open = false;
        }

        if (canvasMenu.activeSelf) { Time.timeScale = 0; } // PlayerPrefs.SetString("podeAndar", "false"); }
        else { Time.timeScale = 1; } // PlayerPrefs.SetString("podeAndar", "true"); }
    }
}
