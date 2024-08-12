using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class agregarDron : MonoBehaviour
{
    [Header("Dron")]
    [SerializeField] GameObject dron;
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
            aplicarItem();
        }
    }

    public void aplicarItem()
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

}
