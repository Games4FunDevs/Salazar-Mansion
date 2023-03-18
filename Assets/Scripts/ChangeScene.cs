using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    EventSystem m_EventSystem;

    void Awake() => m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

    public void ChangeScene_(string name) => SceneManager.LoadScene(name);

    public void Sair() => Application.Quit();

    void OnEnable() 
    {
        if (this.gameObject.transform.parent.gameObject.transform.parent.name == "MenuP1" && this.gameObject.CompareTag("first"))
        {
            m_EventSystem.SetSelectedGameObject(this.gameObject);
        }
    } 
}
