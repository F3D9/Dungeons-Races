using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public GameObject oro;
    public int cantidad_de_oro;
    public AudioClip sonido;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SonidoControler.Instance.ejecutarSonido(sonido);
            collision.GetComponent<Sistema>().oro += cantidad_de_oro;
            Instantiate(oro, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
