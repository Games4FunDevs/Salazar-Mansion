using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    EventSystem m_EventSystem;

    void Awake()
    {
        m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }

    public void ChangeScene_(string name) => SceneManager.LoadScene(name);

    public void Sair() => Application.Quit();

    void OnEnable() 
    {
        if (this.gameObject.transform.parent.gameObject.transform.parent.name.Contains("Menu") && this.gameObject.CompareTag("first"))
        {
            m_EventSystem.SetSelectedGameObject(this.gameObject);
        }
    } 
}
