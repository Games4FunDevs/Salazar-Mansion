using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Update()
    {
        if (this.gameObject.name == "proximaCena")
        {
            ChangeScene_(cena);
        }
    }

    public void ChangeScene_(string name) => SceneManager.LoadScene(name);

    public void Sair() => Application.Quit();

    void OnEnable() 
    {
        if (this.gameObject.CompareTag("first"))
        {
            m_EventSystem.SetSelectedGameObject(this.gameObject);
        }
    } 
}
