using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    private int count1 = 0, count2 = 0;
    private bool aux1, aux2;

    // controles (new input system)
    private Controles controles;

    void Start() 
    {
        // habilita controles
        controles = new Controles();
        controles.Enable();
    }

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

        ChangeBoard();
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

    void SetScale(int canvas_, float x, float y, float z, int child)
    {
        canvas[canvas_].transform.GetChild(child).transform.localScale = new Vector3(x, y, z);
    }

    void ChangeBoard()
    {
        if (controles.P1.Andar.ReadValue<Vector2>().x > 0 && aux1 == false)
        {
            count1++;
            aux1 = true;
        }
        
        if (controles.P1.Andar.ReadValue<Vector2>().x < 0 && aux1 == false)
        {
            count1--;
            aux1 = true;
        }
        
        if (controles.P2.Andar.ReadValue<Vector2>().x > 0 && aux2 == false)
        {
            count2++;
            aux2 = true;
        }
        
        if (controles.P2.Andar.ReadValue<Vector2>().x < 0 && aux2 == false)
        {
            count2--;
            aux2 = true;
        }

        if (controles.P1.Andar.ReadValue<Vector2>().x == 0 && aux1 == true) { aux1 = false; }
        if (controles.P2.Andar.ReadValue<Vector2>().x == 0 && aux2 == true) { aux2 = false; }

        if (count1 > 2) { count1 = 0; }
        if (count2 > 2) { count2 = 0; }

        if (count1 < 0) { count1 = 2; }
        if (count2 < 0) { count2 = 2; }

        switch (count1)
        {
            case 0:
                SetScale(0, 1.23f, 7.15f, 1.63f, 0);
                SetScale(0, 1.08f, 6.27f, 1.63f, 1);
                SetScale(0, 1.08f, 6.27f, 1.63f, 2);
                break;
            case 1:
                SetScale(0, 1.08f, 6.27f, 1.63f, 0);
                SetScale(0, 1.23f, 7.15f, 1.63f, 1);
                SetScale(0, 1.08f, 6.27f, 1.63f, 2);
                break;
            case 2:
                SetScale(0, 1.08f, 6.27f, 1.63f, 0);
                SetScale(0, 1.08f, 6.27f, 1.63f, 1);
                SetScale(0, 1.23f, 7.15f, 1.63f, 2);
                break;
        }
        
        switch (count2)
        {
            case 0:
                SetScale(1, 1.23f, 7.15f, 1.63f, 0); 
                SetScale(1, 1.08f, 6.27f, 1.63f, 1);
                SetScale(1, 1.08f, 6.27f, 1.63f, 2);
                break;
            case 1:
                SetScale(1, 1.08f, 6.27f, 1.63f, 0);
                SetScale(1, 1.23f, 7.15f, 1.63f, 1);
                SetScale(1, 1.08f, 6.27f, 1.63f, 2);
                break;
            case 2:
                SetScale(1, 1.08f, 6.27f, 1.63f, 0);
                SetScale(1, 1.08f, 6.27f, 1.63f, 1);
                SetScale(1, 1.23f, 7.15f, 1.63f, 2);
                break;
        }
    }
}
