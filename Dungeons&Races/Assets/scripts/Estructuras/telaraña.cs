using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telaraña : MonoBehaviour
{
    float velocidad_vieja;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            velocidad_vieja = collision.GetComponent<Sistema>().velocidad;
            collision.GetComponent<Sistema>().velocidad = collision.GetComponent<Sistema>().velocidad_en_telaraña;
            
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Sistema>().velocidad = collision.GetComponent<Sistema>().velocidadNormal;
            collision.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }



}
