using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerPrefsManager : MonoBehaviour
{
    IEnumerator coroutine;

    public GameObject boss, p1, p2, p1Old, p2Old, cinematics, grid1, grid4, panel, luzes, introboss, cutsceneCaveira;

    public bool openBoss, aux = false, cutscenePlay = false;
    
    // public void DeleteComecou() => PlayerPrefs.DeleteKey("ComeçouJogar");

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Time.timeScale = 1;
            if (PlayerPrefs.GetString("EndGame") == "true")
            {
                PlayerPrefs.DeleteAll();
                grid1.SetActive(false);
                grid4.SetActive(true);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("Button (3)"));
            }
        }

        if (SceneManager.GetActiveScene().name == "Fase")
        {
            if (PlayerPrefs.GetString("ArmaPlayerP1") == "true" && PlayerPrefs.GetString("ArmaPlayerP2") == "true" && PlayerPrefs.GetString("CanOpenBossDoor") == "true"
                && cutscenePlay == false)
            {
                introboss.SetActive(true);
                Destroy(panel);
                luzes.SetActive(true);
                p1Old.SetActive(false);
                p2Old.SetActive(false);
                cinematics.SetActive(false);
                cutscenePlay = true;
            }

            if (PlayerPrefs.GetString("LiberouCaveira") == "true" && aux == false)
            {
                Destroy(this.transform.GetChild(0).gameObject);
                Destroy(this.transform.GetChild(1).gameObject);
                Destroy(this.transform.GetChild(2).gameObject);
                cutsceneCaveira.SetActive(true);
                p1Old.transform.position = new Vector3(-1.77f, 0.94f, -41.83f); 
                p1Old.transform.GetChild(2).gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
                p2Old.transform.position = new Vector3(-1.86f, 0.94f, -41.83f);
                p2Old.transform.GetChild(2).gameObject.SetActive(true);
                aux = true;
            }
        }

        // if (PlayerPrefs.GetString("ShowBtnInfo1") == "true")
        // {
        //     coroutine = ShowCanvas("CanvasP1", "ShowBtnInfo1", "false", 10f);
        //     StartCoroutine(coroutine);
        // }
        
        // if (PlayerPrefs.GetString("ShowBtnInfo2") == "true")
        // {
        //     coroutine = ShowCanvas("CanvasP2", "ShowBtnInfo2", "false", 10f);
        //     StartCoroutine(coroutine);
        // }
    }

    public IEnumerator ShowCanvas(string canvas, string btninfo, string value, float time)
    {
        GameObject.Find(canvas).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(time * Time.timeScale);
        GameObject.Find(canvas).gameObject.transform.GetChild(3).gameObject.SetActive(false);
        PlayerPrefs.SetString(btninfo, value);
    }
}
