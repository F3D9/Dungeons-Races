using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMoves : MonoBehaviour
{

    [Header("Cosas")]
    public bool pc = false;
    public Animator animator;
    public float horizontal, vertical;
    Rigidbody2D jugador;
    
    
    Transform puntaArma;
    float anguloRadianes;
    float anguloGrados;

    [Header("Velocidades")]
    float velocidad = 5f;
    float velocidad_normal = 5;
    float velocidad_en_telaraña;

    [Header("Joystick")]
    public Joystick movimiento;
    public Joystick apuntado;

    [Header("Arrows")]
    public float keyboardHorizontal;
    public float keyboardVertical;

    [Header("Utilidad")]
    public bool puedeMoverse = true;

    private void Awake()
    {


        if (PlayerPrefs.GetInt("PcControls") == 1)
        {
            pc = true;
            
        }
        else
        {
            pc= false;
            
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GameObject.FindGameObjectWithTag("apariencia").GetComponent<Animator>();
        jugador = GetComponent<Rigidbody2D>();

        puntaArma = transform.GetChild(0);

        //Size of Joysticks
        movimiento.GetComponent<RectTransform>().localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
        apuntado.GetComponent<RectTransform>().localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
    
    }

    // Update is called once per frame
    void Update()
    {
        if(pc)
        {
            PlayerPrefs.SetInt("PcControls",1);

            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                movimiento.gameObject.SetActive(false);
                apuntado.gameObject.SetActive(false);
            }
            else
            {
                movimiento.gameObject.SetActive(true);
                apuntado.gameObject.SetActive(true);
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("PcControls",0);
            movimiento.gameObject.SetActive(true);
            apuntado.gameObject.SetActive(true);
        }

        //Normal Velocity and trap velocity
        velocidad = GetComponent<Sistema>().velocidad;
        velocidad_en_telaraña = GetComponent<Sistema>().velocidad_en_telaraña;

        animator = GameObject.FindGameObjectWithTag("apariencia").GetComponent<Animator>();

        if (!pc)
        {
            //Joystick

            horizontal = movimiento.Horizontal;
            vertical = movimiento.Vertical;

            if (apuntado.Vertical != 0 && apuntado.Horizontal != 0)
            {
                anguloRadianes = Mathf.Atan2(apuntado.Vertical, apuntado.Horizontal);

                anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
                puntaArma.rotation = Quaternion.Euler(0, 0, anguloGrados);
            }
            else
            {
                puntaArma.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else 
        {
            //Keyboard Input
            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1;
            }
            else
            {
                vertical = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 0;
            
            }
              
            //Keyboard Shoot
        
            if (Input.GetKey(KeyCode.UpArrow))
            {
                keyboardVertical = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                keyboardVertical = -1;
            }
            else
            {
                keyboardVertical = 0.01f;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                keyboardHorizontal = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyboardHorizontal = -1;
            }
            else
            {
                keyboardHorizontal = 0.01f;
            }

            if (keyboardVertical != 0 && keyboardHorizontal != 0)
            {
                anguloRadianes = Mathf.Atan2(keyboardVertical,keyboardHorizontal);

                anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
                puntaArma.rotation = Quaternion.Euler(0, 0, anguloGrados);
            }
            else
            {
                puntaArma.rotation = Quaternion.Euler(0, 0, 0);
            } 


        }

        
        
        

        

    }

    private void FixedUpdate()
    {
        if (animator != null)
        {
            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);
        }
        
        jugador.MovePosition(jugador.position + new Vector2(horizontal, vertical) * velocidad * Time.deltaTime);
        
        
    }
}
