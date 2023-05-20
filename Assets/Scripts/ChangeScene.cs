using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    EventSystem m_EventSystem;
    public string cena;

    void Awake()
    {
        m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ChangeScene_(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Continuar()
    {
        if (PlayerPrefs.GetString("LiberouCaveira") == "true" || PlayerPrefs.GetString("CanOpenBossDoor") == "true")
        {
            ChangeScene_("Fase");
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void DeleteAll_()
    {
        PlayerPrefs.DeleteAll();
        ChangeScene_("Fase");
    }

    public void Sair() => Application.Quit();

    void OnEnable() 
    {
        if (this.gameObject.CompareTag("first"))
        {
            m_EventSystem.SetSelectedGameObject(this.gameObject);
        }
    } 
}
