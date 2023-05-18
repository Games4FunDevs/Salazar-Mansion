using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    private Controles controles;

	public GameObject[] ativos, inativos;

    void Awake()
    {
        controles = new Controles();
        controles.Enable();
    }
    
    void Update()
    {
        if (controles.P1.Fechar.triggered)
	{
		for (int i = 0; i < ativos.Length; i++)
		{
			ativos[i].SetActive(true);
		}

		for (int i = 0; i < inativos.Length; i++)
		{
			inativos[i].SetActive(false);
		}

		this.transform.parent.gameObject.SetActive(false);
	}
    }
}
