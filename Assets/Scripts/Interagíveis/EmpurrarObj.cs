using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurrarObj : MonoBehaviour
{
    public int players = 1, count = 0;
    public bool pushing;

    private Controles controles;
    private Vector2 inputs;
    public Vector3 direction;
    
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
        if (GameObject.Find("P1").GetComponent<PlayerController>().movelCol == true && GameObject.Find("P2").GetComponent<PlayerController>().movelCol == true)
            this.count = 2;
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.gameObject.tag == "P1" && controles.P1.Andar.ReadValue<Vector2>().magnitude > 0f) || (col.gameObject.tag == "P2" && controles.P2.Andar.ReadValue<Vector2>().magnitude > 0f)) 
        {
            if ((players == 1 && count == 1) || (players == 2 && count == 2))
            {
                this.gameObject.transform.position += direction;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "P1" || col.gameObject.name == "P2")
        {
            this.count++;
            pushing = true;
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "P1" || col.gameObject.name == "P2")
        {
            this.count--;
            pushing = false;
        }
    }
}
