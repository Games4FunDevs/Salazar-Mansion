using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoCut : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public GameObject p2cam, p1cam;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        p2cam.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1)
        {
            p2cam.SetActive(true);
            p1cam.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
            Destroy(this.gameObject);
        }
    }
}
