using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    private Controles controles;
    // movimentação
    public  CharacterController controller;
    public Vector2 inputs;
    public float speed = 4f, turnSpeed = 180f;

    // Start is called before the first frame update
    void Start()
    {
        controles = new Controles();
        controles.Enable();
    }

    // Update is called once per frame
    void Update()
    {
       
        inputs = controles.P1.Andar.ReadValue<Vector2>();

        if (inputs.magnitude >= 0.01f)
        {
        Vector3 movDir;
        transform.Rotate(0, inputs.x * turnSpeed * Time.deltaTime, 0);
        movDir = transform.forward * (inputs.y) * speed;
        // moves the character in horizontal direction
        controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);    
        }
        }
       
}
