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
        if ( (p1quadros[0].GetComponent<Image>().color == cores_[0] && p2quadros[0].GetComponent<Image>().color == cores_[2]) 
            ||
            (p1quadros[0].GetComponent<Image>().color == cores_[2] &&
            p2quadros[0].GetComponent<Image>().color == cores_[0]) ) 
        {
            print ("verde");
            p1quadros[0].GetComponent<Image>().color = new Color(0, 1, 0);
            p2quadros[0].GetComponent<Image>().color = new Color(0, 1, 0);
            p1quadros[0].GetComponent<Button>().interactable = false;
            p2quadros[0].GetComponent<Button>().interactable = false;
        }
        
        if ( (p1quadros[1].GetComponent<Image>().color == cores_[0] &&
            p2quadros[1].GetComponent<Image>().color == cores_[1]) 
            ||
            (p1quadros[1].GetComponent<Image>().color == cores_[1] &&
            p2quadros[1].GetComponent<Image>().color == cores_[0]) )
        {
            print ("laranja");
            p1quadros[1].GetComponent<Image>().color = new Color(1.0f, 0.64f, 0.0f);
            p2quadros[1].GetComponent<Image>().color = new Color(1.0f, 0.64f, 0.0f);
            p1quadros[1].GetComponent<Button>().interactable = false;
            p2quadros[1].GetComponent<Button>().interactable = false;
        }
        
        if ( (p1quadros[2].GetComponent<Image>().color == cores_[1] &&
            p2quadros[2].GetComponent<Image>().color == cores_[2]) 
            ||
            (p1quadros[2].GetComponent<Image>().color == cores_[2] &&
            p2quadros[2].GetComponent<Image>().color == cores_[1]) )
        {
            print ("roxo");
            p1quadros[2].GetComponent<Image>().color = new Color(.5f, 0f, 1f);
            p2quadros[2].GetComponent<Image>().color = new Color(.5f, 0f, 1f);
            p1quadros[2].GetComponent<Button>().interactable = false;
            p2quadros[2].GetComponent<Button>().interactable = false;
        } 
    }
}
