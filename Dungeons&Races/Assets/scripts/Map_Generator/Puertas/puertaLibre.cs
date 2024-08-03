using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaLibre : MonoBehaviour
{
    [Header("Libre")]
    public bool libre = true;

    [Header("Conexión")]
    public GameObject puerta_conectada;

    [Header("Sprite Puertas")]
    public List<Sprite> puertaRoja = new List<Sprite>();
    public List<Sprite> puertaVerde = new List<Sprite>();
    public List<Sprite> puertaAmarilla = new List<Sprite>();
    public List<Sprite> puertaAzul = new List<Sprite>();
    public List<Sprite> puertaVioleta = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("analizarHabitaciones", 0.5f);
        
    }


    void analizarHabitaciones()
    {
        if(libre == false && transform.parent.parent.parent.gameObject != GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[0].gameObject)
        {
            if(puerta_conectada.transform.parent.parent.parent.gameObject == GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[0].gameObject)
            {
                reemplazarSprites(puertaRoja);
            }
            if (puerta_conectada.transform.parent.parent.parent.gameObject == GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[1].gameObject)
            {
                reemplazarSprites(puertaVerde);
            }
            if (puerta_conectada.transform.parent.parent.parent.gameObject == GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[2].gameObject)
            {
                reemplazarSprites(puertaAmarilla);
            }
            if (puerta_conectada.transform.parent.parent.parent.gameObject == GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[3].gameObject)
            {
                reemplazarSprites(puertaAzul);
            }
            if (puerta_conectada.transform.parent.parent.parent.gameObject == GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[4].gameObject)
            {
                reemplazarSprites(puertaVioleta);
            }
        }
        
    }

    void reemplazarSprites(List<Sprite> lista)
    {
        switch (transform.GetChild(0).GetComponent<moverseConLasPuertas>().tipo_de_puerta)
        {
            case 1:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lista[0];
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = lista[4];
                break;
            case 2:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lista[1];
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = lista[5];
                break;
            case 3:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lista[2];
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = lista[6];
                break;
            case 4:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lista[3];
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = lista[7];
                break;
        }
    }

}
