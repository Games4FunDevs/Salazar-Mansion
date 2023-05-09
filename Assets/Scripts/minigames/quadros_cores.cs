using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quadros_cores : MonoBehaviour
{
    public int index = 0;
    public GameObject color_;

    // controles (new input system)
    private Controles controles;

    void Start() 
    {
        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        if (this.transform.localScale.x == 1.23f && this.transform.parent.name == "Canvas (2)" && (controles.P1.Interagir.triggered)
            || this.transform.localScale.x == 1.23f && this.transform.parent.name == "Canvas (1)" && (controles.P2.Interagir.triggered))
        {
            ChangeColor(0);
        }
    }

    public void ChangeColor(int y) 
    {
        index++;
        index += y;
        if (index >= color_.GetComponent<quadros_manager>().cores_.Length) { index = 0; }
        this.GetComponent<Image>().color = color_.GetComponent<quadros_manager>().cores_[index]; 
    }
}
