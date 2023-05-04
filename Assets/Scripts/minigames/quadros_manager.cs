using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quadros_manager : MonoBehaviour
{
    public GameObject[] p1quadros;
    public GameObject[] p2quadros;
    public GameObject[] canvas;
    public GameObject[] billboard;
    public GameObject olho;
    public Color[] cores_;
    public bool[] feito;

    void Update()
    {
        Manager(2, 1, 2, new Vector3(.5f, 0, 1), 0);
        Manager(1, 1, 0, new Vector3(1, 0.64f, 0), 1);
        Manager(0, 2, 0, new Vector3(0, 1, 0), 2);

        if (feito[0] == true && feito[1] == true && feito[2] == true)
        {
            Destroy(canvas[0]);
            Destroy(canvas[1]);
            Destroy(billboard[0]);
            Destroy(billboard[1]);
            olho.SetActive(true);
            this.gameObject.GetComponent<quadros_manager>().enabled = false;
        }
    }

    void Manager(int p, int cor1, int cor2, Vector3 cor, int x)
    {
        if ( (p1quadros[p].GetComponent<Image>().color == cores_[cor1] && p2quadros[p].GetComponent<Image>().color == cores_[cor2]) 
            ||
            (p1quadros[p].GetComponent<Image>().color == cores_[cor2] && p2quadros[p].GetComponent<Image>().color == cores_[cor1]) )
        {
            p1quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
            p2quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
            p1quadros[p].GetComponent<Button>().interactable = false;
            p2quadros[p].GetComponent<Button>().interactable = false;
            feito[x] = true; 
        } 
    }
}
