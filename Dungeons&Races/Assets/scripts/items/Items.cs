using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    enum tipo_de_item
    {
        municion,
        apariencia,
        botas,
        corazones,
        velocidad_de_disparo,
        dron,
        mapa,
        volar,
        slime,

    }

    [Header("Tipo de Item")]
    [SerializeField] tipo_de_item item;
    public float precio;

    [Header("Variables")]

    [Header("Municion")]
    public GameObject municion;
    

    [Header("Apariencia")]
    public GameObject apariencia;
    public float aumentoVelocidad;
    public int aparienciaNumero;

    [Header("Corazon")]
    public int agregaVida;
    public Image imagen;
    public bool stand;
    bool rellenar;
    Transform lista;

    [Header("Dron")]
    [SerializeField] GameObject dron;

    [Header("Velocidad de Disparo")]
    [SerializeField] float multiplicador;

    [Header("Slime")]
    [SerializeField] GameObject slimePiso;

    [Header("Sondio")]
    public AudioClip pickup;
    
    [Header("Canva")]
    Canvas canvaItem;
    public string Nombre;
    public string info_mejora;

    // Start is called before the first frame update
    void Start()
    {
        canvaItem = GameObject.FindGameObjectWithTag("ItemCanva").gameObject.GetComponent<Canvas>();
        lista = GameObject.FindGameObjectWithTag("Vida").transform;
        rellenar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aplicar();
        }
    }

    public void aplicar()
    {
        switch (item)
        {
            case tipo_de_item.municion:
                aplicarMunicion();
                break;

            case tipo_de_item.apariencia:
                aplicarApariencia();
                break;

            case tipo_de_item.corazones:
                aplicarCorazones();
                break;

            case tipo_de_item.dron:
                aplicarDron();
                break;

            case tipo_de_item.velocidad_de_disparo:
                aplicarVelocidadDisparo();
                break;

            case tipo_de_item.botas:
                aplicarVelocidad();
                break;

            case tipo_de_item.mapa:
                aplicarMapa();
                break;

            case tipo_de_item.slime:
                aplicarSlime();
                break;

        }
    }

    void aplicarMunicion()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<disparo>().bala = municion;
        SonidoControler.Instance.ejecutarSonido(pickup);
        Destroy(gameObject);
    }

    void aplicarApariencia()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        SonidoControler.Instance.ejecutarSonido(pickup);
        Destroy(GameObject.FindGameObjectWithTag("apariencia").gameObject);
        Instantiate(apariencia, GameObject.FindGameObjectWithTag("Player").gameObject.transform);
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidad *= aumentoVelocidad;
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidadNormal = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidad;
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().apariencia = aparienciaNumero;
        Destroy(gameObject);
    }

    void aplicarCorazones()
    {
        SonidoControler.Instance.ejecutarSonido(pickup);
        if (stand)
        {
            canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        }


        for (int i = 0; i < lista.childCount; i++)
        {
            if (lista.GetChild(i).GetComponent<Image>().fillAmount == 0.5f)
            {

                rellenar = true;
            }
        }

        for (int i = 0; i < agregaVida; i++)
        {
            if (rellenar)
            {
                lista.GetChild(lista.childCount - 1).GetComponent<Image>().fillAmount = 1;
                Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(45f, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Vida").transform);
                lista.GetChild(lista.childCount - 1).GetComponent<Image>().fillAmount = 0.5f;
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.childCount - 1).GetComponent<Image>());
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vidaTotal += agregaVida;
            }
            else
            {
                Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(45f, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Vida").transform);
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.transform.childCount - 1).GetComponent<Image>());
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vidaTotal += agregaVida;

            }
        }
        Destroy(gameObject);
    }

    void aplicarDron()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        SonidoControler.Instance.ejecutarSonido(pickup);
        if (GameObject.FindGameObjectWithTag("Dron") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Dron").gameObject);
            Instantiate(dron, GameObject.FindGameObjectWithTag("Player").transform);
        }
        else
        {

            Instantiate(dron, GameObject.FindGameObjectWithTag("Player").transform);
        }
        Destroy(gameObject);
    }

    void aplicarVelocidadDisparo()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").GetComponent<disparo>().condicion *= multiplicador;
        SonidoControler.Instance.ejecutarSonido(pickup);
        Destroy(gameObject);
    }

    void aplicarVelocidad()
    {
        SonidoControler.Instance.ejecutarSonido(pickup);
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidad *= aumentoVelocidad;
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidadNormal = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<Sistema>().velocidad;
        Destroy(gameObject);
    }
    void aplicarMapa()
    {
        SonidoControler.Instance.ejecutarSonido(pickup);
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("BotonMapa").transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject);
    }

    void aplicarSlime()
    {
        SonidoControler.Instance.ejecutarSonido(pickup);
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Sistema>().slime = slimePiso;
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Sistema>().crearSlime = true;
        Destroy(gameObject);
    }

}
