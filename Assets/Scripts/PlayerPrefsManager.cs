using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerPrefsManager : MonoBehaviour
{
    IEnumerator coroutine;

    public GameObject boss, p1, p2, salazar, p1Old, p2Old, cinematics, grid1, grid4, panel, luzes, introboss, cutsceneCaveira, musboss, brutos, sufocado, painel;
    public CutsceneInicial cutsinicial;
    public GameObject[] descartaveis;

    public bool openBoss, aux, cutscenePlay = false;
    
    // public void DeleteComecou() => PlayerPrefs.DeleteKey("ComeçouJogar");

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Time.timeScale = 1;
            if (PlayerPrefs.GetString("EndGame") == "true")
            {
                PlayerPrefs.DeleteAll();
                this.gameObject.GetComponent<PlayerPrefsManager>().enabled = false;
            }
        }

        Save();
    }

    public void Save()
    {
        if (SceneManager.GetActiveScene().name == "Fase")
        {
            if (PlayerPrefs.GetString("SaveStatus") == "Boss")
            {
                introboss.SetActive(true);
                Destroy(panel);
                luzes.SetActive(true);
                Destroy(p1Old);
                Destroy(p2Old);
                Destroy(cinematics);
                cutscenePlay = true;
                p1.transform.position = new Vector3(-10.7200003f,14.5900002f,-46.3899994f);
                salazar.transform.position = new Vector3(-14.6110001f,13.6999998f,-45.4900017f);
                for (int i = 0; i < descartaveis.Length; i++)
                {
                    Destroy(descartaveis[i]);
                }
                this.gameObject.GetComponent<PlayerPrefsManager>().enabled = false;
            }
            else if (PlayerPrefs.GetString("SaveStatus") == "caveira")
            {
                Destroy(this.transform.GetChild(0).gameObject);
                cutsceneCaveira.SetActive(true);
                p1Old.SetActive(true);
                p2Old.SetActive(true);
                musboss.SetActive(false);
                p1Old.transform.position = new Vector3(-1.77f, 0.94f, -41.83f); 
                brutos.transform.position = new Vector3(-7.5f,-0.0500000007f,-20.2299995f); 
                brutos.transform.rotation = new Quaternion(0,1,0,0); 
                p1Old.transform.GetChild(2).gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
                p2Old.transform.position = new Vector3(-1.86f, 0.94f, -41.83f);
                p2Old.transform.GetChild(2).gameObject.SetActive(true);
                this.gameObject.GetComponent<PlayerPrefsManager>().enabled = false;
            }
            else if (PlayerPrefs.GetString("SaveStatus") == "andar1")
            {
                Destroy(this.transform.GetChild(0).gameObject);
                if (PlayerPrefs.GetString("P1HasKey2") == "true")
                    { p1Old.GetComponent<PlayerController>().hasKey2 = true; }
                if (PlayerPrefs.GetString("P2HasKey2") == "true")
                    { p2Old.GetComponent<PlayerController>().hasKey2 = true; }
                p1Old.SetActive(true);
                musboss.SetActive(false);
                p2Old.SetActive(true);
                p1Old.transform.position = new Vector3(-13.39f, 7.73f, -48f); 
                p1Old.transform.GetChild(2).gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
                p2Old.transform.position = new Vector3(-15f, 7.73f, -48.5f);
                p2Old.transform.GetChild(2).gameObject.SetActive(true);
                Time.timeScale = 1;
                this.gameObject.GetComponent<PlayerPrefsManager>().enabled = false;
            }
            else 
            {
                p1Old.transform.position = new Vector3(5.5999999f,1.00999999f,-24.4300003f);
                p2Old.transform.position = new Vector3(-2.56999993f,1.00999999f,-14.4700003f);
                p1Old.SetActive(false);
                p2Old.SetActive(false);
                p1Old.transform.GetChild(2).gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
                cutsinicial.count = 0;
                painel.SetActive(true);
                sufocado.SetActive(false);
            }
        }
    }
}
