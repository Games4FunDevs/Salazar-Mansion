using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoon : MonoBehaviour
{
    private Controles controles;
    private Vector2 inputs;

    public bool unlocked = false, canOpen = false;
    public Animator anim;

    public bool openTrigger, closeTrigger;
    public string openDoor = "OpenDoor1", closeDoor = "CloseDoor1";
    public GameObject other, p2free, p2cam;

    public AudioClip[] sons;
    AudioSource audio_;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();

        audio_ = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider col)
    {
        if (!this.unlocked && ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || 
            (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1)))
        {
            if (col.gameObject.GetComponent<PlayerController>().hasKey == true 
                || (col.gameObject.GetComponent<PlayerController>().hasKey2 == true && this.transform.parent.name.Contains("DoorArmas")) 
                || (col.gameObject.GetComponent<PlayerController>().hasLockp == true && (this.transform.parent.name.Contains("DoorCamareira") || this.transform.parent.name.Contains("DoorDespensa")))
                || (col.gameObject.GetComponent<PlayerController>().hasKey3 == true && this.transform.parent.name.Contains("DoorEscadas"))
                || (PlayerPrefs.GetString("ArmaPlayerP1") == "true" && PlayerPrefs.GetString("ArmaPlayerP2") == "true" && this.transform.parent.name.Contains("DoorBoss"))
                )
            {
                GetComponent<AudioSource>().clip = sons[2];
                GetComponent<AudioSource>().Play();
                this.unlocked = true;
                other.GetComponent<OpenDoon>().unlocked = true;
                StartCoroutine("Unlock", 0.3f);

                if (col.gameObject.GetComponent<PlayerController>().hasKey == true)
                { 
                    col.gameObject.GetComponent<PlayerController>().hasKey = false; 
                    Destroy(GameObject.Find("key1-item"));
                }
                
                if (this.transform.parent.name.Contains("DoorEscadas"))
                {
                    if (col.gameObject.GetComponent<PlayerController>().hasKey3 == true)
                    { 
                        col.gameObject.GetComponent<PlayerController>().hasKey3 = false; 
                        Destroy(GameObject.Find("key3-item"));
                        Destroy(GameObject.Find("DescItem Tranca (2)"));
                    }
                }
                

                if (col.gameObject.GetComponent<PlayerController>().hasLockp == true)
                { 
                    col.gameObject.GetComponent<PlayerController>().hasLockp = false; 
                    Destroy(GameObject.Find("lockpick-item"));
                    if (this.transform.parent.name.Contains("DoorCamareira"))
                        Destroy(GameObject.Find("DescItem Tranca (1)"));

                    if (this.transform.parent.name.Contains("DoorDespensa"))
                        Destroy(GameObject.Find("DescItem Tranca Despensa"));
                }

                if (this.transform.parent.name.Contains("DoorArmas"))
                {
                    Destroy(GameObject.Find("key2-item"));
                }
                
                if (this.transform.parent.name.Contains("DoorBoss"))
                {
                    Destroy(GameObject.Find("DescItem boss"));
                    PlayerPrefs.SetString("CanOpenBossDoor", "true");
                }
            }
        }
        
        if (this.unlocked == true)
        {
            if (this.canOpen == true && ((col.CompareTag("P1") && controles.P1.Interagir.ReadValue<float>() == 1) || 
            (col.CompareTag("P2") && controles.P2.Interagir.ReadValue<float>() == 1))
            && this.openTrigger)
            {
                this.anim.Play(openDoor, 0, 0);
                GetComponent<AudioSource>().clip = sons[0];
                GetComponent<AudioSource>().Play();
                this.other.GetComponent<OpenDoon>().closeTrigger = true;
                this.openTrigger = false;
            }
        }
        

        if (col.CompareTag("Inimigo") && this.openTrigger)
        {
            this.anim.Play(openDoor, 0, 0);
            GetComponent<AudioSource>().clip = sons[0];
            GetComponent<AudioSource>().Play();
            this.other.GetComponent<OpenDoon>().closeTrigger = true;
            this.openTrigger = false;
        }
    }

    void OnTriggerExit(Collider col) 
    {
        if ((col.CompareTag("P1") || col.CompareTag("P2")) && closeTrigger)
        {
            anim.Play(closeDoor, 0, 0);
            audio_.clip = sons[1];
            audio_.Play();
            this.other.GetComponent<OpenDoon>().openTrigger = true;
            closeTrigger = false;
        }
    }

    IEnumerator Unlock()
    {
        yield return new WaitForSeconds(.3f);
        this.canOpen = true;
        other.GetComponent<OpenDoon>().canOpen = true;
    }
}
