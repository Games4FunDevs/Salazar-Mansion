using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurrarObj : MonoBehaviour
{
    public int players = 1;
    public string eixo = "x";

    public GameObject parent, col_;

    private Controles controles;
    private Vector2 inputs;
    
    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        if (this.gameObject.name.Contains("Leve"))
            this.players = 1;
        else if (this.gameObject.name.Contains("Pesado"))
            this.players = 2;
    }

    void Update()
    {
        if (this.transform.parent.name.Contains("P"))
        {
            if (eixo == "x")
                col_.GetComponent<PlayerController>().inputs.y = 0;
            else if (eixo == "y")
                col_.GetComponent<PlayerController>().inputs.x = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)) 
        {
            this.gameObject.transform.SetParent(col.transform);
            this.col_ = col.gameObject;
        }
        else if ((col.CompareTag("P1") &&controles.P1.Interagir.ReadValue<float>() == 0) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 0))
        {
            this.gameObject.transform.SetParent(parent.transform);
        }
    }
}
