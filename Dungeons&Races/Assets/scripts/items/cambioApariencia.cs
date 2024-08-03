using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioApariencia : MonoBehaviour
{

    [Header("Ajustes")]
    public GameObject apariencia;
    public float aumentoVelocidad;
    public int aparienciaNumero;
    public AudioClip pickup;

    [Header("Canva")]
    Canvas canvaItem;
    public string Nombre;
    public string info_mejora;
    // Start is called before the first frame update
    void Start()
    {
        canvaItem = GameObject.FindGameObjectWithTag("ItemCanva").gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
            SonidoControler.Instance.ejecutarSonido(pickup);
            Destroy(GameObject.FindGameObjectWithTag("apariencia").gameObject);
            Instantiate(apariencia, collision.transform);
            collision.GetComponent<Sistema>().velocidad *= aumentoVelocidad;
            collision.GetComponent<Sistema>().velocidadNormal = collision.GetComponent<Sistema>().velocidad;
            collision.GetComponent<Sistema>().apariencia = aparienciaNumero;
            Destroy(gameObject);
        }
    }

    public void aplicarItem()
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

}
