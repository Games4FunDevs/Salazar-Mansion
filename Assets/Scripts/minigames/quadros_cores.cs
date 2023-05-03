using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quadros_cores : MonoBehaviour
{
    public int index = 0;
    public GameObject color_;

    public void ChangeColor()
    {
        index++;
        if (index >= color_.GetComponent<quadros_manager>().cores_.Length) { index = 0; }
        this.GetComponent<Image>().color = color_.GetComponent<quadros_manager>().cores_[index]; 
    }
}
