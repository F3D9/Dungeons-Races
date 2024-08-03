using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarCondicion : MonoBehaviour
{
    [SerializeField] float multiplicador;
    [SerializeField] AudioClip pickup;

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
            aplicarItem();
        }
    }


    public void aplicarItem()
    {
        canvaItem.GetComponent<ItemsCanva>().cargarCanvaItem(Nombre, info_mejora);
        GameObject.FindGameObjectWithTag("Player").GetComponent<disparo>().condicion *= multiplicador;
        SonidoControler.Instance.ejecutarSonido(pickup);
        Destroy(gameObject);
    }
}
