using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    public GameObject cutscene, p2cam, callInimigo;
    public int count = 0;
    public bool p1, p2;

    void Awake()
    {
        cutscene.SetActive(false);
    }

    void Update()
    {
        if (this.count == 1 && cutscene.activeSelf == false) 
        {
            if (this.gameObject.name == "p2free")
            {
                DestroyCutscene();
            } 
            if (this.gameObject.name == "meninoc1")
            {
                callInimigo.SetActive(true);
                DestroyCutscene();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("P1")) { p1 = true; } 
        else if (col.CompareTag("P2")) { p2 = true; }

        if (this.count == 0)
        {
            if ((this.gameObject.name == "p2free" && p1 == true) 
            || ((p1 == true && p2 == true) && this.gameObject.name == "meninoc1")
            || ((this.gameObject.name == "fimfase1" && (p1 == true || p2 == true)))) 
            {
                CallCustcene();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("P1"))
        {
            p1 = false;
        } 
        else if (col.CompareTag("P2"))
        {
            p2 = false;
        }
    }

    void CallCustcene()
    {
        this.cutscene.SetActive(true);
        //p2cam.SetActive(false);
        this.count = 1;
    }

    void DestroyCutscene()
    {
        Destroy(this.gameObject);
    }
}
