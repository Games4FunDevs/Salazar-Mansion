using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUnlock : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false, peca = false;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay(Collider col)
    {
        if (peca == false && (col.CompareTag("P1") && col.GetComponent<PlayerController>().hasPeca == true && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && col.GetComponent<PlayerController>().hasPeca == true && controles.P2.Interagir.ReadValue<float>() == 1))
        {
            StartCoroutine("PecaTrue", .3f);
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
        }

        if (peca == true && (col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)) 
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
            this.GetComponent<Animator>().Play("alavanca", 0, 0);
            this.gameObject.GetComponent<EnergyUnlock>().enabled = false;
        }
    }

    IEnumerator PecaTrue()
    {
        yield return new WaitForSeconds(.3f);
        peca = true;
    }
}
