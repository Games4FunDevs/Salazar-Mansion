using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurrarObj : MonoBehaviour
{
    public int players = 1, count = 0;
    public bool pushing, canMove = true;

    private Controles controles;
    private Vector2 inputs;
    public Vector3 direction;

    public GameObject gp1, gp2;
    
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
        if (gp1 != null && gp2 != null)
            this.count = 2;
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.gameObject.tag == "P1" && controles.P1.Andar.ReadValue<Vector2>().magnitude > 0f) || (col.gameObject.tag == "P2" && controles.P2.Andar.ReadValue<Vector2>().magnitude > 0f)) 
        {
            if (((players == 1 && count == 1) || (players == 2 && count == 2)) && canMove)
            {
                this.gameObject.transform.position += direction;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (gp1 != null || gp2 != null)
        {
            if (GameObject.Find("DescItemMovelL") != null)
            {
                GameObject.Find("DescItemMovelL").gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            // if (GameObject.Find("DescItemMovelP") != null)
            // {
            //     GameObject.Find("DescItemMovelP").gameObject.GetComponent<BoxCollider>().enabled = false;
            // }
            pushing = true;
        }

        if ((gp1 != null && gp2 == null) || ((gp1 == null && gp2 != null)))
        {
            this.count = 1;
        }
        else if (gp1 != null && gp2 != null)
        {
            this.count = 2;
        }

        if (col.gameObject.name == "P1")
            gp1 = col.gameObject;
            
        if (col.gameObject.name == "P2")
            gp2 = col.gameObject;

        if (col.gameObject.name == "stopMovel")//
        {
            canMove = false;
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            if (GameObject.Find("DescItemMovelL") != null) GameObject.Find("DescItemMovelL").GetComponent<ShowCanvasText>().showing = false;
            // if (GameObject.Find("DescItemMovelP") != null) GameObject.Find("DescItemMovelP").GetComponent<ShowCanvasText>().showing = false;
            
            if (GameObject.Find("FalaP1") != null) GameObject.Find("FalaP1").SetActive(false);
            if (GameObject.Find("FalaP2") != null) GameObject.Find("FalaP2").SetActive(false);
                
            if (GameObject.Find("DescItemMovelL") != null) Destroy(GameObject.Find("DescItemMovelL").gameObject);

            Destroy(col.gameObject);
            this.gameObject.GetComponent<EmpurrarObj>().enabled = false;
        }

        if (count == 2)
        {
            if (GameObject.Find("DescItemMovelP") != null) GameObject.Find("DescItemMovelL").GetComponent<ShowCanvasText>().showing = false;

            if (GameObject.Find("FalaP1") != null) GameObject.Find("FalaP1").SetActive(false);
            if (GameObject.Find("FalaP2") != null) GameObject.Find("FalaP2").SetActive(false);

            if (GameObject.Find("DescItemMovelP") != null) Destroy(GameObject.Find("DescItemMovelP").gameObject);
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "P1" || col.gameObject.name == "P2")
        {
            //this.count--;
            pushing = false;
        }

        if (col.gameObject.name == "P1")
            gp1 = null;
            
        if (col.gameObject.name == "P2")
            gp2 = null;
    }
}
