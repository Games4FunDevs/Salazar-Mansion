using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTip : MonoBehaviour
{
    public GameObject Dica1, Dica2;
    // Start is called before the first frame update

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P1")
        {
            if(Dica1 != null){Dica1.SetActive(true);}
        }
        if(other.gameObject.tag == "P2")
        {
            if(Dica2 != null){Dica2.SetActive(true);}
        }

    }

    
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "P1")
        {
            if(Dica1 != null){Dica1.SetActive(false);}
        }
        if(other.gameObject.tag == "P2")
        {
            if(Dica2 != null){Dica2.SetActive(false);}
        }
    }
}
