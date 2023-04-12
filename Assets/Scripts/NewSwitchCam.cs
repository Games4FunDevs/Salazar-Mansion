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
    
    private Controles controles;
    private Collider other_, other_1;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("P1"))
        {
            other_ = other;

            P1naCena = true;
            P1 = other.transform;
            activeCam.Priority = 1;
            activeCam.LookAt = P1.transform;
            Cam.layer = 6;

            if (controles.P1.Andar.ReadValue<Vector2>().magnitude == 0)
                other.GetComponent<PlayerController>().cameuleranglesy = Cam.transform.eulerAngles.y;
        }

        if (other.CompareTag("P2"))
        {
            other_1 = other;

            P2naCena = true;
            P2 = other.transform;
            activeCam.Priority = 1;
            activeCam.LookAt = P2.transform;
            Cam.layer = 7;

            if (controles.P2.Andar.ReadValue<Vector2>().magnitude == 0)
                other.GetComponent<PlayerController>().cameuleranglesy = Cam.transform.eulerAngles.y;
        }

        if(P1naCena == true && P2naCena == true)
        {
            target_2 = true;
            if (target_2 == true)
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

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("P1"))
        {
            P1naCena = false;
            P1 = other.transform;
            activeCam.Priority = 0;
            activeCam.LookAt = null;
            Cam.layer = 0;
        }

        if (other.CompareTag("P2"))
        {
            P2naCena = false;
            P2 = other.transform;
            activeCam.Priority = 0;
            activeCam.LookAt = null;
            Cam.layer = 0;
        }
    }
}
