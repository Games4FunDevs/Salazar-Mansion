using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCutscene : MonoBehaviour
{   public GameObject Cutscene;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P1" || other.gameObject.tag == "P2")
        {
            Cutscene.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
