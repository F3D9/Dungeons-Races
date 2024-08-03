using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoves : MonoBehaviour
{
    [Header("Cosas")]
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

    [Header("Utilidad")]
    public bool puedeMoverse = true;


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GameObject.FindGameObjectWithTag("apariencia").GetComponent<Animator>();
        jugador = GetComponent<Rigidbody2D>();
        puntaArma = transform.GetChild(0);
        movimiento.GetComponent<RectTransform>().localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
        apuntado.GetComponent<RectTransform>().localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
    
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = GetComponent<Sistema>().velocidad;
        velocidad_en_telaraña = GetComponent<Sistema>().velocidad_en_telaraña;
        animator = GameObject.FindGameObjectWithTag("apariencia").GetComponent<Animator>();
        horizontal = movimiento.Horizontal; 
        vertical = movimiento.Vertical; 
        if(apuntado.Vertical != 0 && apuntado.Horizontal != 0)
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
