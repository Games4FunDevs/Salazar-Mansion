using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    IEnumerator coroutine;
    
    public void DeleteComecou() => PlayerPrefs.DeleteKey("ComeçouJogar");

    void Update()
    {
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
