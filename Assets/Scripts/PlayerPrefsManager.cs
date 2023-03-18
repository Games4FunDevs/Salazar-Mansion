using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteKey("P1X");
        PlayerPrefs.DeleteKey("P1Y");
        PlayerPrefs.DeleteKey("P2X");
        PlayerPrefs.DeleteKey("P2Y");
    }
}
