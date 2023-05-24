using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSelect : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
