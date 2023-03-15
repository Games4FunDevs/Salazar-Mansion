using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesAcionaveisManager : MonoBehaviour
{
    public bool[] botoes;
    public GameObject door;
    
    void Update()
    {
        botoes[0] = this.transform.GetChild(0).gameObject.GetComponent<BotoesAcionaveis1>().status;
        botoes[1] = this.transform.GetChild(1).gameObject.GetComponent<BotoesAcionaveis1>().status; 

        if (botoes[0] && botoes[1])
        {
            door.transform.GetChild(0).GetComponent<OpenDoon>().unlocked = true;
            door.GetComponent<Animator>().Play("OpenDoor2", 0, 0);
        }
    }
}
