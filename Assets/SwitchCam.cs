using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCam : MonoBehaviour
{
    public GameObject Cam, P1, P2;
    public GameObject P1cam, P2cam, Maincam;
    public CinemachineVirtualCamera virtualCamera;
    public bool P1naCena,P2naCena,estaoNaCena;
    public GameObject target;
    // Start is called before the first frame update
    void Update() 
    {
        if(P1naCena == true && P2naCena == true)
        {estaoNaCena = true;
        if(estaoNaCena == true)
        {
        virtualCamera.Follow = target.transform; virtualCamera.LookAt = target.transform;
        Cam.gameObject.layer = 0; 
        }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("P1"))
        {
            Cam.SetActive(true);
            P1naCena = true;
            P1 = other.gameObject;
            if(P1naCena == true && P2naCena == false)
            {
            virtualCamera.Follow = P1.transform; virtualCamera.LookAt = P1.transform;
            Cam.gameObject.layer = 6;
            } 
        }
        if(other.CompareTag("P2"))
        {
            Cam.SetActive(true);
            P2naCena = true;
            P2 = other.gameObject;
            if(P2naCena == true && P1naCena == false)
            {
            virtualCamera.Follow = P2.transform; virtualCamera.LookAt = P2.transform;
            Cam.gameObject.layer = 7;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if(other.CompareTag("P1"))
        {
            P1naCena = false;
            P1 = null;
            if(P2 != null)
            {
            virtualCamera.Follow = P2.transform; virtualCamera.LookAt = P2.transform;
            Cam.gameObject.layer = 7;
            }
           
        }
        if(other.CompareTag("P2"))
        {
            P2naCena = false;
            P2 = null;
            if(P1 != null)
            {
            virtualCamera.Follow = P1.transform; virtualCamera.LookAt = P1.transform;
            Cam.gameObject.layer = 6;
            }
            
        }
        if(P1naCena == false && P2naCena == false)
        {
            Cam.SetActive(false);
            Cam.layer = 0;
            virtualCamera.Follow = null; virtualCamera.LookAt = null; 
        }
    }
}
