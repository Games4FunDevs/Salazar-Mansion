using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // controles (new input system)
    private Controles controles;

    [SerializeField] private string modoMov;

    // movimentação
    private CharacterController controller;
    public Vector2 inputs;
    public Transform cam; // direcao da camera
    public float curSpeed, runSpeed = 6f; //walkSpeed = 3f, , pushSpeed = 2fvelocidades
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

    // itens / inventario
    public bool hasKey1 = false, 
                hasPeca = false, 
                hasEye = false,
                hasEye2 = false,
                hasKey2 = false,
                hasKey3 = false,
                hasLockp = false,
                hasArma = false;
    
    public GameObject inimigo, falap1, falap2;

    private AudioSource audio_, audio_1;

    void Awake()
    {
        HideCursor();

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
                this.modoMov = PlayerPrefs.GetString("P1ModoMov");
                break;
            case "P2":
                this.player = 2;
                this.modoMov = PlayerPrefs.GetString("P2ModoMov");
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

        if (hasKey2 == true && GameObject.Find("impedirEscadas") != null && GameObject.Find("impedirEscadas").activeSelf)
        {
            Destroy(GameObject.Find("impedirEscadas"));
        }
        
        if (PlayerPrefs.GetString("Inimigo1Spawn") == "true")
        {
           inimigo.SetActive(true);
           PlayerPrefs.SetString("Inimigo1Spawn", "spawnado");
        }

        if (this.gameObject.name == "P1")
        {
            if (falap1.activeSelf && controles.P1.Interagir.triggered)
            {
                falap1.SetActive(false);
            }
        }
        if (this.gameObject.name == "P2")
        {
            if (falap2.activeSelf && controles.P2.Interagir.triggered)
            {
                falap2.SetActive(false);
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ((this.gameObject.name == "P1" && controles.P1.Interagir.triggered) || (this.gameObject.name == "P2" && controles.P2.Interagir.triggered))
        {
            if (col.gameObject.name.Contains("Key1"))
            {
                this.hasKey1 = true;
                Destroy(col.gameObject);
            }
            
            if (col.gameObject.name.Contains("Key3"))
            {
                this.hasKey3 = true;
                Destroy(col.gameObject);
            }

            if (col.gameObject.name.Contains("Key2"))
            {
                this.hasKey2 = true;
                Destroy(col.gameObject);
                PlayerPrefs.SetString(this.gameObject.name+"HasKey2", "true");
            }
            
            if (col.gameObject.name.Contains("Peça"))
            {
                this.hasPeca = true;
                Destroy(col.gameObject);
            }
            
            if (col.gameObject.name == "Olho de vidro")
            {
                this.hasEye = true;
                Destroy(col.gameObject);
            }
            
            if (col.gameObject.name == "Olho de vidro 2")
            {
                this.hasEye2 = true;
                Destroy(col.gameObject);
            }
            
            if (col.gameObject.name == "Lockpick")
            {
                this.hasLockp = true;
                Destroy(col.gameObject);
            }
            
            if (!hasArma && col.gameObject.name == "Arma")
            {
                this.hasArma = true;
                PlayerPrefs.SetString("ArmaPlayer"+this.gameObject.name, "true");
                Destroy(col.gameObject);
            }
        }   

        if (col.gameObject.name.Contains("Chamar Cutscene - Andar 1")) 
        {
            PlayerPrefs.SetString("SaveStatus", "andar1");
        } 
        
        if (col.gameObject.name == "fimfase1")
        {
            Destroy(GameObject.Find("Inimigo"));
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

    
        if (this.inputs.magnitude >= 0.01f)  
        {
            if (this.modoMov == "Tank") // tank
            {
                Vector3 movDir;
                transform.Rotate(0, inputs.x * 400 * Time.deltaTime, 0);
                movDir = transform.forward * (inputs.y) * curSpeed;
                // moves the character in horizontal direction
                controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f); 
            }
            else // moderno
            {
                float targetAngle = Mathf.Atan2(this.inputs.x, this.inputs.y) * Mathf.Rad2Deg + cameuleranglesy;  // direcao que player vai rotacionar + onde a camera tiver olhando
                this.angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TURNSMOOTHTIME); // calcula o angulo e tempo pra virar smooth
                this.transform.rotation = Quaternion.Euler(0f, this.angle, 0f); // rotaciona player
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // vira pra direcao
                this.mover = moveDir.normalized * curSpeed * Time.deltaTime;
                this.controller.Move(mover); // actually move player
                
            }
        }
    }

    void Gravity() // adiciona gravidade
    {
        // checa se ta no chao
        isGrounded = Physics.CheckSphere(GameObject.FindWithTag("GCheck").transform.position, 0.2f, Ground, QueryTriggerInteraction.Ignore);
        _velocity.y += gravidade * Time.deltaTime * Time.timeScale; // direcao da gravidade
        controller.Move(_velocity * Time.deltaTime * Time.timeScale); // aplica gravidade

        if (isGrounded && _velocity.y < 0)
            _velocity.y = -2f * Time.timeScale;
    }

    void Run() 
    {
        switch (player)
        {
            case 1:
                // if (isGrounded && controles.P1.Correr.ReadValue<float>() == 1)
                //     curSpeed = runSpeed * Time.timeScale;
                    
                if (isGrounded && controles.P1.Correr.ReadValue<float>() == 0)
                    curSpeed = runSpeed * Time.timeScale;
                    // curSpeed = walkSpeed * Time.timeScale;
            break;
            case 2:
                // if (isGrounded && controles.P2.Correr.ReadValue<float>() == 1)
                //     curSpeed = runSpeed * Time.timeScale;
                    
                if (isGrounded && controles.P2.Correr.ReadValue<float>() == 0)
                    curSpeed = runSpeed * Time.timeScale;
                    // curSpeed = walkSpeed * Time.timeScale;
            break;
        }
    }

    void Animations()
    {
        // if (curSpeed == walkSpeed)
        // {
        //     anim.SetInteger("state", 1);
        //     this.audio_.enabled = true;
        //     this.audio_1.enabled = false;
        // }
        if (curSpeed == runSpeed) 
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
