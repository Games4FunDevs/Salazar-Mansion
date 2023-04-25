using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica2 : MonoBehaviour
{
    public Animator animatorP1, animatorP2;
    
    // Start is called before the first frame update

    public void Idle_P1()
    {
        animatorP1.GetComponent<Animator>().SetBool("Fala",false);
        animatorP1.GetComponent<Animator>().SetBool("Fala2",false);
    }
    public void Idle_P2()
    {
        animatorP2.GetComponent<Animator>().SetBool("Fala",false);
    }
     public void Fala_1P1()
    {
        animatorP1.GetComponent<Animator>().SetBool("Fala",true);
        animatorP1.GetComponent<Animator>().SetBool("Fala2",false);
    }
     public void Fala2_P1()
    {
        animatorP1.GetComponent<Animator>().SetBool("Fala2",true);
         animatorP1.GetComponent<Animator>().SetBool("Fala",false);
    }
    public void Fala1_P2()
    {
        animatorP2.GetComponent<Animator>().SetBool("Fala",true);
    } 
}
