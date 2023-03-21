using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    IEnumerator coroutine;

    void Awake()
    {
        PlayerPrefs.DeleteKey("P1X");
        PlayerPrefs.DeleteKey("P1Y");
        PlayerPrefs.DeleteKey("P2X");
        PlayerPrefs.DeleteKey("P2Y");
    }
    
    public void DeleteComecou() => PlayerPrefs.DeleteKey("ComeçouJogar");

    void Update()
    {
        if (PlayerPrefs.GetString("ShowBtnInfo1") == "true")
        {
            coroutine = ShowCanvas("CanvasP1", "ShowBtnInfo1", "false");
            StartCoroutine(coroutine);
        }
        
        if (PlayerPrefs.GetString("ShowBtnInfo2") == "true")
        {
            coroutine = ShowCanvas("CanvasP2", "ShowBtnInfo2", "false");
            StartCoroutine(coroutine);
        }
    }

    IEnumerator ShowCanvas(string canvas, string btninfo, string value)
    {
        GameObject.Find(canvas).gameObject.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        GameObject.Find(canvas).gameObject.transform.GetChild(3).gameObject.SetActive(false);
        PlayerPrefs.SetString(btninfo, value);
    }
}
