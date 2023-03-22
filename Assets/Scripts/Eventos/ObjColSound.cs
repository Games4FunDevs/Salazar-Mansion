using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColSound : MonoBehaviour
{
    public bool istrigger_, destroy, coliderEnable, callEnemy;
    public float time = 2f;
    public GameObject destroyNow, enemy;

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

            if (coliderEnable == false)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (destroyNow != null)
            {
                Destroy(destroyNow);
            }
            if (destroy == true)
            {
                StartCoroutine("Destroy", time);
            }
            if (callEnemy == true)
            {
                enemy.SetActive(true);
            }
        }
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time); 
        Destroy(this.gameObject);
    }
}
