using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurrarObj : MonoBehaviour
{
    public int players = 1, count = 0;
    public string eixo = "x";
    public float forceMagnitude = 1;
    public bool pushing;

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
        if (GameObject.Find("P1").GetComponent<PlayerController>().movelCol == true && GameObject.Find("P2").GetComponent<PlayerController>().movelCol == true)
            count = 2;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "P1" || col.gameObject.name == "P2")
            count = 1;

        if ((players == 1 && count == 1) || (players == 2 && count == 2))
        {
            if ((col.gameObject.tag == "P1" && controles.P1.Andar.ReadValue<Vector2>().magnitude > 0f) || (col.gameObject.tag == "P2" && controles.P2.Andar.ReadValue<Vector2>().magnitude > 0f)) 
            {
                this.gameObject.transform.position += new Vector3(.01f, 0, 0);
                pushing = true;
            }
            else if ((col.gameObject.tag == "P1" && controles.P1.Andar.ReadValue<Vector2>().magnitude == 0f) || (col.gameObject.tag == "P2" && controles.P2.Andar.ReadValue<Vector2>().magnitude == 0f))
            {
                pushing = false;
            }
        }
    }
}
