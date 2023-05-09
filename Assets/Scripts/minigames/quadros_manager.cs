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
    public GameObject olho, chave;
    public Color[] cores_;
    public bool[] feito;
    public int count1 = 0, count2 = 0;
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
        if (this.gameObject.name.Contains("1"))
        {
            StartCoroutine(Manager(0, 3, 1, new Vector3(.5f, 0, 1), 0)); // roxo
        }

        if (this.gameObject.name.Contains("2"))
        {
            StartCoroutine(Manager(2, 3, 1, new Vector3(.5f, 0, 1), 2)); // roxo 
            StartCoroutine(Manager(1, 1, 0, new Vector3(1, 0.64f, 0), 1)); //laranja 
            StartCoroutine(Manager(0, 0, 3, new Vector3(0, 1, 0), 0)); // verde
        }

        if ((this.gameObject.name.Contains("2") && feito[0] == true && feito[1] == true && feito[2] == true) 
            || (this.gameObject.name.Contains("1") && feito[0] == true))
        {
            StartCoroutine("Delay", 1f);
        }

        if (this.gameObject.name.Contains("2"))
        {
            ChangeBoard();
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("P1").GetComponent<PlayerController>().enabled = true; 
        GameObject.Find("P2").GetComponent<PlayerController>().enabled = true; 
        Destroy(canvas[0]);
        Destroy(canvas[1]);
        Destroy(billboard[0]);
        Destroy(billboard[1]);
        olho.SetActive(true);
        this.transform.GetChild(3).gameObject.SetActive(true);
        this.gameObject.GetComponent<quadros_manager>().enabled = false;
    }

    IEnumerator Manager(int p, int cor1, int cor2, Vector3 cor, int x)
    {
        if ( (p1quadros[p].GetComponent<Image>().color == cores_[cor1] && p2quadros[p].GetComponent<Image>().color == cores_[cor2]) 
            ||
            (p1quadros[p].GetComponent<Image>().color == cores_[cor2] && p2quadros[p].GetComponent<Image>().color == cores_[cor1]) )
        {
            p1quadros[p].GetComponent<quadros_cores>().enabled = false;
            p2quadros[p].GetComponent<quadros_cores>().enabled = false;
            yield return new WaitForSeconds(1f);
            p1quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
            p2quadros[p].GetComponent<Image>().color = new Color(cor.x, cor.y, cor.z);
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

        if (count1 > 3) { count1 = 0; }
        if (count2 > 3) { count2 = 0; }

        if (count1 < 0) { count1 = 3; }
        if (count2 < 0) { count2 = 3; }

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
