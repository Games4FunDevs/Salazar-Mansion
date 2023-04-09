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
    public float cameuleranglesy;

    // gravidade
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask Ground; // layer dos objs q sao chão
    private Vector3 _velocity;
    private float gravidade = -20f;

    public int player = 0;

    // teste
    public bool hasKey = false, hasPeca = false;
    
    public GameObject canvasMenu;

    private AudioSource audio_, audio_1;

    void Awake()
    {
        HideCursor();

        PlayerPrefs.SetString("P1Menu", "false");
        PlayerPrefs.SetString("P2Menu", "false");

        // configura variaveis
        this.controller = GetComponent<CharacterController>();
        // cam = GameObject.FindWithTag("P1 cam").GetComponent<Transform>();
        anim = transform.GetChild(1).GetComponent<Animator>(); // acessa o corpo
        // habilita controles
        controles = new Controles();
        controles.Enable();

        audio_ = GetComponent<AudioSource>();
        audio_1 = gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>();

        switch (this.gameObject.name)
        {
            case "P1":
                this.player = 1;
                break;
            case "P2":
                this.player = 2;
                break;
        }

        cameuleranglesy = cam.eulerAngles.y;
    }

    void Update()
    {
        Gravity();
        Animations();

        if (PlayerPrefs.GetString("podeAndar") == "true")
        {
            Movement(); // pode andar
            Run(); // pode correr
        }

        if (player == 1)
        {
            if (controles.P1.Menu.triggered) ShowMenu();
        }
        else if (player == 2)
        {
            if (controles.P2.Menu.triggered) ShowMenu();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name.Contains("Key") && (controles.P1.Interagir.triggered || controles.P2.Interagir.triggered))
        {
            this.hasKey = true;
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.name.Contains("Peça") && (controles.P1.Interagir.triggered || controles.P2.Interagir.triggered))
        {
            this.hasPeca = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "EndGame") // final do jogo
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
            float targetAngle = Mathf.Atan2(this.inputs.x, this.inputs.y) * Mathf.Rad2Deg + cameuleranglesy;  // direcao que player vai rotacionar + onde a camera tiver olhando
            this.angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TURNSMOOTHTIME); // calcula o angulo e tempo pra virar smooth
            this.transform.rotation = Quaternion.Euler(0f, this.angle, 0f); // rotaciona player
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // vira pra direcao
            this.mover = moveDir.normalized * curSpeed * Time.deltaTime;
            this.controller.Move(mover); // actually move player
        }

        // if (this.inputs.magnitude >= 0.01f)
        // {
        //     Vector3 movDir;
        //     transform.Rotate(0, inputs.x * 180 * Time.deltaTime, 0);
        //     movDir = transform.forward * (inputs.y) * curSpeed;
        //     // moves the character in horizontal direction
        //     controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f); 
        // }
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
                    curSpeed = runSpeed;
                    
                if (isGrounded && controles.P2.Correr.ReadValue<float>() == 0)
                    curSpeed = walkSpeed;
            break;
        }
    }

    void Animations()
    {
        if (curSpeed == walkSpeed)
        {
            anim.SetInteger("state", 1);
            this.audio_.enabled = true;
            this.audio_1.enabled = false;
        }
        else if (curSpeed == runSpeed) 
        {
            anim.SetInteger("state", 2);
            this.audio_.enabled = false;
            this.audio_1.enabled = true;
        }

        if (inputs.magnitude <= 0)
        {
            anim.SetInteger("state", 0);
            audio_.enabled = false;
            audio_1.enabled = false;
        }
    }

    void ShowMenu()
    {
        if (this.canvasMenu.activeSelf)
        {
            if (this.player == 1)
            {
                PlayerPrefs.SetString("P1Menu", "false");
                CanvasMenuSet(false, "true");
            }
            if (this.player == 2)
            {
                PlayerPrefs.SetString("P2Menu", "false");
                CanvasMenuSet(false, "true");
            }
        }
        else
        {
            if (this.player == 1 && PlayerPrefs.GetString("P2Menu") == "false")
            {
                PlayerPrefs.SetString("P1Menu", "true");
                CanvasMenuSet(true, "false");
            }
            if (this.player == 2 && PlayerPrefs.GetString("P1Menu") == "false")
            {
                PlayerPrefs.SetString("P2Menu", "true");
                CanvasMenuSet(true, "false");
            }
        }
    }

    void CanvasMenuSet(bool value, string podeandar)
    {
        this.canvasMenu.SetActive(value);
        PlayerPrefs.SetString("podeAndar", podeandar);
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
