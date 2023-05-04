using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showFPS : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh.GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(ContarFPS), 0, 1f );
    }

    void ContarFPS()
    {
        if(Input.GetKey("1")){textMesh.enabled = true;}
        if(Input.GetKey("2")){textMesh.enabled = false;}
        textMesh.text = (1f / Time.deltaTime).ToString("00") + " FPS";
    }
    void Update()
    {
        
    }
}
