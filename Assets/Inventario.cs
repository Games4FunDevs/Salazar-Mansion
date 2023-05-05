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
    public bool[] varAux = {false, false, false, false, false, false};

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
            Instanciar(0, "key1-item");
        }
        if (player.hasPeca && !varAux[1])
        {
            Instanciar(1, "peca-item");
        }
        if (player.hasEye && !varAux[2])
        {
            Instanciar(2, "eye1-item");
        }
        if (player.hasKey2 && !varAux[3])
        {
            Instanciar(3, "key2-item");
        }
        if (player.hasEye2 && !varAux[4])
        {
            Instanciar(4, "eye2-item");
        }
    }

    void Instanciar(int x, string name_)
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(this.transform);
        obj.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprites[x];
        obj.name = name_;
        varAux[x] = !varAux[x];
    }
}
