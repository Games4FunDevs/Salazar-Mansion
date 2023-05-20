using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    public PlayerController player; // correspondente
    public GameObject slotPrefab; // spawn do slot
    public Sprite[] sprites;
    public GameObject canvas;
    private string[] desc = { "Chave do freezer", "Fusível", "Olho de vidro", "Chave da sala de armas", "Olho de vidro", "Lockpick", "Arma", "Chave pro 2º andar" };
    public bool[] varAux = {false, false, false, false, false, false, false}; 

    void Update()
    {
        if (player.hasKey1 && !varAux[0])
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
        if (player.hasLockp && !varAux[5])
        {
            Instanciar(5, "lockpick-item");
        }
        if (player.hasArma && !varAux[6])
        {
            Instanciar(6, "arma-item");
        }
        if (player.hasKey3 && !varAux[7])
        {
            Instanciar(7, "key3-item");
        }
    }

    void Instanciar(int x, string name_)
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(this.transform);
        obj.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprites[x];
        canvas.GetComponent<Image>().sprite = sprites[x];
        canvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = desc[x];
        obj.name = name_;
        varAux[x] = !varAux[x];
        StartCoroutine("ShowAndHide", 2f);
    }

    IEnumerator ShowAndHide()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }
}
