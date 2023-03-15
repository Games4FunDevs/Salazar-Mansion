using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewSwitchCam : MonoBehaviour
{
    public Transform P1, P2, target;
    public bool P1naCena, P2naCena, target_2, switchMov;
    public CinemachineVirtualCamera activeCam;
    public GameObject Cam;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("P1"))
        {
            P1naCena = true;
            P1 = other.transform;
            activeCam.Priority = 1;
            activeCam.LookAt = P1.transform;
            Cam.layer = 6;
        }
        if(other.CompareTag("P2"))
        {
            P2naCena = true;
            P2 = other.transform;
            activeCam.Priority = 1;
            activeCam.LookAt = P2.transform;
            Cam.layer = 7;
        }
        if(P1naCena == true && P2naCena == true)
        {
            if(target_2 == true)
            {
            activeCam.Priority = 1;
            activeCam.LookAt = target;
            Cam.layer = 0;
            }
            else
            {
            activeCam.Priority = 1;
            activeCam.LookAt = null;
            Cam.layer = 0;
            }
           
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("P1"))
        {
            P1naCena = false;
            P1 = other.transform;
            activeCam.Priority = 0;
            activeCam.LookAt = null;
            Cam.layer = 0;
        }
          if(other.CompareTag("P2"))
        {
            P2naCena = false;
            P2 = other.transform;
            activeCam.Priority = 0;
            activeCam.LookAt = null;
            Cam.layer = 0;
        }
    }
}
