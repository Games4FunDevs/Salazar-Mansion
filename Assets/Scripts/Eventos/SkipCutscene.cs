using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    private Controles controles;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }
    
    void Update()
    {
        
    }
}
