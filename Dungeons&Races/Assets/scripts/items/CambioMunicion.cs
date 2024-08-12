using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMunicion : MonoBehaviour
{
    public GameObject municion;
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

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
            collision.gameObject.GetComponent<disparo>().bala = municion;
            SonidoControler.Instance.ejecutarSonido(pickup);
            Destroy(gameObject);
        }
    }

    public void aplicarItem()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetComponent<disparo>().bala = municion;
        SonidoControler.Instance.ejecutarSonido(pickup);
        Destroy(gameObject);
    }
}
