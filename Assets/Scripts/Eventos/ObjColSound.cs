using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColSound : MonoBehaviour
{
    public bool istrigger_, destroy;
    public float time = 2f;

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Ground" && istrigger_ == false)
            this.gameObject.GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter (Collider col)
    {
        if ((col.CompareTag("P1") || col.CompareTag("P2")) && istrigger_ == true)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            if (destroy == true)
                StartCoroutine("Destroy", time);
        }
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time); 
        Destroy(this.gameObject);
    }
}
