using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class vecinos : MonoBehaviour
{
    [Header("Cantidad de vecinos")]
    public int cantidad_de_vecinos;

    [Header("Vecinos y sus posiciones")]
    public GameObject vecino_arriba;
    bool arriba;
    public GameObject vecino_abajo;
    bool abajo;
    public GameObject vecino_derecha;
    bool derecha;
    public GameObject vecino_izquierda;
    bool izquierda;

    [Header("Cantidad de Habitaciones")]
    public int habitaciones;

    // Start is called before the first frame update
    void Start()
    {
        arriba = false;
        abajo = false;
        derecha = false;
        izquierda = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(vecino_arriba != null && arriba == false)
        {
            cantidad_de_vecinos++;
            
            arriba = true;
            
        }

        if(vecino_abajo != null && abajo == false)
        {
            cantidad_de_vecinos++;
            
            abajo = true;

        }

        if(vecino_derecha != null && derecha == false)
        {
            cantidad_de_vecinos++;
            
            derecha = true;

        }

        if(vecino_izquierda != null && izquierda == false)
        {
            cantidad_de_vecinos++;
            
            izquierda = true;
        }

    }

    public void buscar_vecinos()
    {
        
        for (int i = 0; i < habitaciones; i++)
        {
            if (new Vector2(transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.x, transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.y) == new Vector2(transform.position.x + 20f, transform.position.y))
            {
                vecino_derecha = transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].gameObject;
                transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<puertaLibre>().puerta_conectada = vecino_derecha.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
                transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<puertaLibre>().libre = false;
                
            }

            if (new Vector2(transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.x, transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.y) == new Vector2(transform.position.x - 20f, transform.position.y))
            {
                vecino_izquierda = transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].gameObject;
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<puertaLibre>().puerta_conectada = vecino_izquierda.transform.GetChild(0).GetChild(1).GetChild(2).gameObject;
                transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<puertaLibre>().libre = false;
            }

            if (new Vector2(transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.x, transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.y) == new Vector2(transform.position.x, transform.position.y + 10f))
            {
                vecino_arriba = transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].gameObject;
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<puertaLibre>().puerta_conectada = vecino_arriba.transform.GetChild(0).GetChild(1).GetChild(3).gameObject;
                transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<puertaLibre>().libre = false;
            }

            if (new Vector2(transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.x, transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].transform.position.y) == new Vector2(transform.position.x, transform.position.y - 10f))
            {
                vecino_abajo = transform.parent.GetComponentInParent<generadorMapa>().habitacionesCreadas[i].gameObject;
                transform.GetChild(0).GetChild(1).GetChild(3).GetComponent<puertaLibre>().puerta_conectada = vecino_abajo.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
                transform.GetChild(0).GetChild(1).GetChild(3).GetComponent<puertaLibre>().libre = false;
            }

        }

    }
}
