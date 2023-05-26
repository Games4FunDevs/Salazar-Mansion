using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent nma;
    public GameObject gameover, btn, p1, p2;
    public Transform[] targetPlayer; 

    void Start() => nma = GetComponent<NavMeshAgent>();

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Vector3.Distance(transform.position, targetPlayer[0].position) > 
                Vector3.Distance(transform.position, targetPlayer[1].position))
                nma.SetDestination(targetPlayer[1].position);
            else
                nma.SetDestination(targetPlayer[0].position);
        }
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "P1" || col.gameObject.tag == "P2")
        {
            gameover.SetActive(true);
            EventSystem.current.SetSelectedGameObject(btn);
            p1.SetActive(false);
            p2.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
