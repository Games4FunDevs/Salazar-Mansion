using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;

    // movimentação
    private CharacterController controller;
    public Vector2 inputs;
    public Transform cam; // direcao da camera
    public float curSpeed, walkSpeed = 3f, runSpeed = 6f, pushSpeed = 2f; // velocidades
    private float turnSmoothVelocity, TURNSMOOTHTIME = 0.135f, angle; // velocidade de rotacao
    private Vector3 mover; // direcao e velocidade pra
    public Animator anim;

    // gravidade
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask Ground; // layer dos objs q sao chão
    private Vector3 _velocity;
    private float gravidade = -20f;

    public int player = 0;

    // teste
    public bool hasKey = false;

    AudioSource audio;

    void Awake()
    {
        // configura variaveis
        this.controller = GetComponent<CharacterController>();
        // cam = GameObject.FindWithTag("P1 cam").GetComponent<Transform>();
        anim = transform.GetChild(1).GetComponent<Animator>(); // acessa o corpo
        // habilita controles
        controles = new Controles();
        controles.Enable();

        audio = GetComponent<AudioSource>();

        switch (this.gameObject.name)
        {
            case "P1":
                this.player = 1;
                break;
            case "P2":
                this.player = 2;
                break;
        }
    }

    void Update()
    {
        Movement();
        Gravity();
        Run();
        HideCursor();
        Animations();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name.Contains("Key") && (controles.P1.Interagir.triggered || controles.P2.Interagir.triggered))
        {
            this.hasKey = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "EndGame")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void Movement() // movimentação baseada no input e direção da camera
    {
        if (this.player == 1)
            this.inputs = controles.P1.Andar.ReadValue<Vector2>();

        if (this.player == 2)
            this.inputs = controles.P2.Andar.ReadValue<Vector2>();

        if (this.inputs.magnitude >= 0.01f) // se ta movendo pra qualquer direcao == apertou botão
        {
            float targetAngle = Mathf.Atan2(this.inputs.x, this.inputs.y) * Mathf.Rad2Deg + cam.eulerAngles.y;  // direcao que player vai rotacionar + onde a camera tiver olhando
            this.angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TURNSMOOTHTIME); // calcula o angulo e tempo pra virar smooth
            this.transform.rotation = Quaternion.Euler(0f, this.angle, 0f); // rotaciona player
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // vira pra direcao
            this.mover = moveDir.normalized * curSpeed * Time.deltaTime;
            this.controller.Move(mover); // actually move player
            this.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }

    void Gravity() // adiciona gravidade
    {
        // checa se ta no chao
        isGrounded = Physics.CheckSphere(GameObject.FindWithTag("GCheck").transform.position, 0.2f, Ground, QueryTriggerInteraction.Ignore);
        _velocity.y += gravidade * Time.deltaTime; // direcao da gravidade
        controller.Move(_velocity * Time.deltaTime); // aplica gravidade

        if (isGrounded && _velocity.y < 0)
            _velocity.y = -2f;
    }

    void Run() 
    {
        switch (player)
        {
            case 1:
                if (isGrounded && controles.P1.Correr.ReadValue<float>() == 1)
                {
                    curSpeed = runSpeed;
                }
                if (isGrounded && controles.P1.Correr.ReadValue<float>() == 0)
                {
                    curSpeed = walkSpeed;
                }
                break;
            case 2:
                if (isGrounded && controles.P2.Correr.ReadValue<float>() == 1)
                {
                    curSpeed = runSpeed;
                }
                if (isGrounded && controles.P2.Correr.ReadValue<float>() == 0)
                {
                    curSpeed = walkSpeed;
                }
                break;
        }
    }

    void Animations()
    {
        switch (curSpeed)
        {
            case 3:
                anim.SetInteger("state", 1);
                break;
            case 6:
                anim.SetInteger("state", 2);
                break;
        }

        if (inputs.magnitude <= 0)
        {
            anim.SetInteger("state", 0);
            this.gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

    // void ShowCursor()
    // {
    //     Cursor.lockState = CursorLockMode.Confined;
    //     Cursor.visible = true;
    // }

    void HideCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
