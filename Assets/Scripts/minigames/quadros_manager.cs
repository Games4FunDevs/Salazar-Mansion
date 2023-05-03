using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quadros_manager : MonoBehaviour
{
    public GameObject[] p1quadros;
    public GameObject[] p2quadros;
    public Color[] cores_;

    void Update()
    {
        Manager(2, 1, 2, new Vector3(.5f, 0, 1));
        Manager(1, 1, 0, new Vector3(1, 0.64f, 0));
        Manager(0, 2, 0, new Vector3(0, 1, 0));
    }

    void Manager(int p, int cor1, int cor2, Vector3 cor)
    {
        if ( (p1quadros[p].GetComponent<Image>().color == cores_[cor1] && p2quadros[p].GetComponent<Image>().color == cores_[cor2]) 
            ||
            (p1quadros[p].GetComponent<Image>().color == cores_[cor2] && p2quadros[p].GetComponent<Image>().color == cores_[cor1]) )
        {
            p1quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
            p2quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
            p1quadros[p].GetComponent<Button>().interactable = false;
            p2quadros[p].GetComponent<Button>().interactable = false;
        } 
    }
}
