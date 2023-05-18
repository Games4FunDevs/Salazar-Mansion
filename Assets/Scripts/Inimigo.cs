using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent nma;
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
            SceneManager.LoadScene("GameOver");
        }
    }
}
