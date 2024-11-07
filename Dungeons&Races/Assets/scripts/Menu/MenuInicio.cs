using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    [Header("Joysticks")]
    public Image OpcionesControles;
    public RectTransform move, shoot;
    public Slider slide;
    float numero;
    [SerializeField] Joystick moves;
    [SerializeField] Joystick shot;

    [Header("Volume")]
    public AudioMixer controlVolumen;
    public Image volume;
    public Slider volumeEffects;
    public Slider volumeMusic;
    float sonidoEfectos;
    float sonidoMusica;

    [Header("Valores")]
    public GameObject mover;
    [SerializeField] float velocidad;

    [Header("Lado De Controles")]
    [SerializeField] RectTransform moverse;
    [SerializeField] RectTransform disparar;
    [SerializeField] TextMeshProUGUI botonLado;
    [SerializeField] bool right = true;

    [Header("Tipo de Controles")]
    [SerializeField] bool pc = true;
    [SerializeField] TextMeshProUGUI botonTipoDeControl;

    [Header("Sprites Personajes")]
    [SerializeField] Image panel2;
    [SerializeField] Image panel1;

    [Header("Canva Carga")]
    public GameObject carga;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        carga = GameObject.FindGameObjectWithTag("Carga").gameObject;
        OpcionesControles.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        carga.transform.GetChild(0).gameObject.SetActive(false);

        //CARGA EL VOLUMEN 
        controlVolumen.SetFloat("VolMusic", PlayerPrefs.GetFloat("Music"));
        controlVolumen.SetFloat("VolFX", PlayerPrefs.GetFloat("Effects"));
        
        //CARGA EL TAMAÑO DE LOS CONTROLLES
        if(PlayerPrefs.GetFloat("TamañoJoysticks") == 0)
        {
            PlayerPrefs.SetFloat("TamañoJoysticks", 1);
        }
        
        slide.value = PlayerPrefs.GetFloat("TamañoJoysticks");

        //RESETEA EL SCORE
        PlayerPrefs.SetInt("Score", 0);

        PlayerPrefs.SetInt("PcControls", 1);

        //Tipo de Control
        if (PlayerPrefs.GetInt("PcControls")==1) 
        {
            pc = true;
            botonTipoDeControl.text = "PC";
        }
        else
        {
            pc =false;
            botonTipoDeControl.text = "MOBILE";
        }


        

        //CARGA EL LADO DE LOS CONTROLES
        moverse = GameObject.FindGameObjectWithTag("joystickMover").GetComponent<RectTransform>();
        disparar = GameObject.FindGameObjectWithTag("joystickDisparar").GetComponent<RectTransform>();

        if (PlayerPrefs.GetInt("LadoControles") == 1)
        {
            botonLado.text = "Right";
            right = true;
        }
        else
        {
            botonLado.text = "Left";
            Vector3 posicionShoot = disparar.position;
            disparar.position = moverse.position;
            moverse.position = posicionShoot;
            right = false;
        }
         

    }

    // Update is called once per frame
    void Update()
    {

        moves = GameObject.FindGameObjectWithTag("joystickMover").GetComponent<Joystick>();
        shot = GameObject.FindGameObjectWithTag("joystickDisparar").GetComponent<Joystick>();

        moverse = GameObject.FindGameObjectWithTag("joystickMover").GetComponent<RectTransform>();
        disparar = GameObject.FindGameObjectWithTag("joystickDisparar").GetComponent<RectTransform>();


    }

    // JOYSTICK OPCIONES
    public void tamaño_Joysticks(float valor)
    {
        numero = valor;
        PlayerPrefs.SetFloat("TamañoJoysticks", numero);
        move.localScale = new Vector3(0.36f, 0.36f, 0.36f) * valor;
        shoot.localScale = new Vector3(0.36f, 0.36f, 0.36f) * valor;
        moverse.localScale = new Vector3(0.36f, 0.36f, 0.36f) * valor;
        disparar.localScale = new Vector3(0.36f, 0.36f, 0.36f) * valor;
    }
    public void mostrarTamañoJoystick()
    {
        OpcionesControles.gameObject.SetActive(true);
        LeanTween.moveY(OpcionesControles.GetComponent<RectTransform>(),0,velocidad).setEase(LeanTweenType.easeOutQuad);
        move.localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
        shoot.localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
        moverse.localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
        disparar.localScale = new Vector3(0.36f, 0.36f, 0.36f) * PlayerPrefs.GetFloat("TamañoJoysticks");
    }

    public void esconderTamañoJoystick()
    {
        LeanTween.moveY(OpcionesControles.GetComponent<RectTransform>(), 105, velocidad).setEase(LeanTweenType.easeOutQuad);
        Invoke("esconder", 0.6f);
        
    }

    //VOLUMEN OPCIONES

    public void valoresEfectos(float valor1)
    {
        sonidoEfectos = valor1;
        PlayerPrefs.SetFloat("Effects", sonidoEfectos);
        controlVolumen.SetFloat("VolFX", sonidoEfectos);
    }

    public void valoresMusica(float valor2)
    {
        sonidoMusica = valor2;
        PlayerPrefs.SetFloat("Music", sonidoMusica);
        controlVolumen.SetFloat("VolMusic", sonidoMusica);
    }

    public void mostrarVolumen()
    {
        volume.gameObject.SetActive(true);
        LeanTween.moveY(volume.GetComponent<RectTransform>(), 0, velocidad).setEase(LeanTweenType.easeOutQuad);
        volumeEffects.value = PlayerPrefs.GetFloat("Effects");
        volumeMusic.value = PlayerPrefs.GetFloat("Music");

        //ESTO HACE QUE LOS SLIDER FUNCIONEN
        volumeEffects.onValueChanged.AddListener(valoresEfectos);
        volumeMusic.onValueChanged.AddListener(valoresMusica);

        
    }

    public void esconderVolumen()
    {
        LeanTween.moveY(volume.GetComponent<RectTransform>(), 105, velocidad).setEase(LeanTweenType.easeOutQuad);
        Invoke("esconder", 0.6f);
    }


    void esconder()
    {
        OpcionesControles.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        
    }

    public void ladoDeLosControles()
    {
        if (right)
        {
            Vector3 posicionShoot = disparar.position;
            disparar.position = moverse.position;
            moverse.position = posicionShoot;
            botonLado.text = "Left";
            PlayerPrefs.SetInt("LadoControles", 0);
            right = false;
        }
        else
        {
            Vector3 posicionShoot = disparar.position;
            disparar.position = moverse.position;
            moverse.position = posicionShoot;
            botonLado.text = "Right";
            PlayerPrefs.SetInt("LadoControles", 1);
            right = true;
        }
    }


    //Platform

    public void typeControls()
    {
        if (pc)
        {
            botonTipoDeControl.text = "MOBILE";
            PlayerPrefs.SetInt("PcControls", 0);
            pc = false;
        }
        else
        {
            PlayerPrefs.SetInt("PcControls", 1);
            botonTipoDeControl.text = "PC";
            pc = true;
            
        }
    }

    //MENU 1

    public void Play()
    {
        carga.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void moverIzquierdaOptions()
    {
        
        LeanTween.moveX(mover.GetComponent<RectTransform>(), 785, velocidad).setEase(LeanTweenType.easeOutQuad);
    }

    public void moverDerechaInicio()
    {
        LeanTween.moveX(mover.GetComponent<RectTransform>(), -860, velocidad).setEase(LeanTweenType.easeOutQuad);
    }

    public void moverDerechaTabla()
    {
        LeanTween.moveX(mover.GetComponent<RectTransform>(), -1680, velocidad).setEase(LeanTweenType.easeOutQuad);
    }

    public void moverCentro()
    {
        LeanTween.moveX(mover.GetComponent<RectTransform>(), -30, velocidad).setEase(LeanTweenType.easeOutQuad);
    }

    //Personajes

    public void cambiarPersonaje(GameObject Personaje)
    {
        GuardarGameObjects.Instance = null;
        Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
        Instantiate(Personaje, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        GameObject.FindGameObjectWithTag("Player").GetComponent<GuardarGameObjects>().guardarObjecto();
        

    }
    
    public void cambiarSprite(Sprite sprite)
    {
        panel1.sprite = sprite;
        panel2.sprite = sprite;

    }


}
