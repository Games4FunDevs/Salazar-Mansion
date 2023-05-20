using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool eyes = false, eye1 = false, eye2 = false;
    public GameObject cinematic;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if ((col.CompareTag("P1") && col.GetComponent<PlayerController>().hasEye == true && controles.P1.Interagir.ReadValue<float>() == 1) 
            || (col.CompareTag("P2") && col.GetComponent<PlayerController>().hasEye == true && controles.P2.Interagir.ReadValue<float>() == 1))
        {
            this.transform.GetChild(6).gameObject.SetActive(true);
            eye1 = true;
            Destroy(GameObject.Find("eye1-item"));
        }

        if ((col.CompareTag("P1") && col.GetComponent<PlayerController>().hasEye2 == true && controles.P1.Interagir.ReadValue<float>() == 1) 
            || (col.CompareTag("P2") && col.GetComponent<PlayerController>().hasEye2 == true && controles.P2.Interagir.ReadValue<float>() == 1))
        {
            this.transform.GetChild(7).gameObject.SetActive(true);
            eye2 = true;
            Destroy(GameObject.Find("eye2-item"));
        }

        if (eyes == false &&
            (col.CompareTag("P1") && eye1 == true && eye2 == true  && controles.P1.Interagir.ReadValue<float>() == 1) 
            || (col.CompareTag("P2") && eye1 == true && eye2 == true && controles.P2.Interagir.ReadValue<float>() == 1))
        {
            cinematic.SetActive(true);
            eyes = true;
            if (PlayerPrefs.GetString("SaveStatus") != "caveira") 
                { PlayerPrefs.SetString("SaveStatus", "caveira"); }
            // StartCoroutine("EyeTrue", .3f);
            //this.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    IEnumerator EyeTrue()
    {
        yield return new WaitForSeconds(.3f);
        cinematic.SetActive(true);
    }
}
