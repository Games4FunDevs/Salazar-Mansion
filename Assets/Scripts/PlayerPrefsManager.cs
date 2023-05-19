using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerPrefsManager : MonoBehaviour
{
    IEnumerator coroutine;

    public GameObject boss, p1, p2, p1Old, p2Old, cinematics, grid1, grid4, panel, luzes, introboss;

    public bool openBoss, cutscenePlay = false;
    
    public void DeleteComecou() => PlayerPrefs.DeleteKey("ComeçouJogar");

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
                // boss.SetActive(true);
                // p1.SetActive(true);
                // p2.SetActive(true);
                p1Old.SetActive(false);
                p2Old.SetActive(false);
                cinematics.SetActive(false);
                cutscenePlay = true;
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
