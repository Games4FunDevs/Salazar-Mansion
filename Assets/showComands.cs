using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showComands : MonoBehaviour
{
    void Update()
    {
        StartCoroutine("ShowCanvas", 10);
    }

    public IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(10);
        this.gameObject.SetActive(false);
    }
}
