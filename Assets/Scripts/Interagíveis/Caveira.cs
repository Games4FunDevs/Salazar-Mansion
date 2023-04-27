using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool eye = false;
    public GameObject cinematic;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if (eye == false && (col.CompareTag("P1") && col.GetComponent<PlayerController>().hasEye == true && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && col.GetComponent<PlayerController>().hasEye == true && controles.P2.Interagir.ReadValue<float>() == 1))
        {
            StartCoroutine("EyeTrue", .3f);
            //this.transform.GetChild(3).gameObject.SetActive(false);
            
        }
    }

    IEnumerator EyeTrue()
    {
        yield return new WaitForSeconds(.3f);
        this.transform.GetChild(6).gameObject.SetActive(true);
        eye = true;
        cinematic.SetActive(true);
    }
}
