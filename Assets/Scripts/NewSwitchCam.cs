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
    public Vector2 inputSaved1, inputSaved2, inputChanged1, inputChanged2;
    private Collider other_, other_1;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }

    void Update()
    {
        inputChanged1 = controles.P1.Andar.ReadValue<Vector2>();
        inputChanged2 = controles.P2.Andar.ReadValue<Vector2>();
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

            inputChanged1 = new Vector2(PlayerPrefs.GetFloat("P1X"), PlayerPrefs.GetFloat("P1Y"));
            if (controles.P1.Andar.ReadValue<Vector2>().magnitude == 0 && inputChanged1 != inputSaved1)
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

            inputChanged2 = new Vector2(PlayerPrefs.GetFloat("P2X"), PlayerPrefs.GetFloat("P2Y"));
            if (controles.P2.Andar.ReadValue<Vector2>().magnitude == 0 && inputChanged2 != inputSaved2)
                other.GetComponent<PlayerController>().cameuleranglesy = Cam.transform.eulerAngles.y;
        }

        if (P1naCena == true && P2naCena == true)
        {
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

            inputSaved1 = controles.P1.Andar.ReadValue<Vector2>();
            PlayerPrefs.SetFloat("P1X", inputSaved1.x);
            PlayerPrefs.SetFloat("P1Y", inputSaved1.y);
        }

        if (other.CompareTag("P2"))
        {
            P2naCena = false;
            P2 = other.transform;
            activeCam.Priority = 0;
            activeCam.LookAt = null;
            Cam.layer = 0;

            inputSaved2 = controles.P2.Andar.ReadValue<Vector2>();
            PlayerPrefs.SetFloat("P2X", inputSaved2.x);
            PlayerPrefs.SetFloat("P2Y", inputSaved2.y);
        }
    }
}
