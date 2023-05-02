using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private PlayerController player; // correspondente
    public GameObject slotPrefab; // spawn do slot
    public Sprite[] sprites;
    private string[] nomes;
    public bool[] varAux = {false, false, false, false, false};

    void Awake()
    {
        // vai acessar o player correspondente
        if (this.transform.parent.name.Contains("P1"))
            player = GameObject.Find("P1").GetComponent<PlayerController>();
        else if (this.transform.parent.name.Contains("P2"))
            player = GameObject.Find("P2").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.hasKey && !varAux[0])
        {
            Instanciar(0);
        }
        if (player.hasPeca && !varAux[1])
        {
            Instanciar(1);
        }
        if (player.hasEye && !varAux[2])
        {
            Instanciar(2);
        }
        if (player.hasKey2 && !varAux[3])
        {
            Instanciar(3);
        }
    }

    void Instanciar(int x)
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.parent = this.transform;
        obj.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprites[x];
        varAux[x] = !varAux[x];
    }
}
