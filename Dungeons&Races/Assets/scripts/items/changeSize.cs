using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSize : MonoBehaviour
{

    [Header("Ajustes")]
    [SerializeField] float size;
    public AudioClip pickup;

    [Header("Canva")]
    Canvas canvaItem;
    public string Nombre;
    public string info_mejora;

    void Start()
    {
        canvaItem = GameObject.FindGameObjectWithTag("ItemCanva").gameObject.GetComponent<Canvas>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }


    public void aplicarItem()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        SonidoControler.Instance.ejecutarSonido(pickup);
        GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(size, size, size);
    }

}
