    using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CorazonBlanco : MonoBehaviour
{
    [Header("Ajustes")]
    public int agregaVida;
    public Image imagen;
    public bool stand;
    public int tipoDeItem;
 
    public AudioClip pickup;
    [Header("Canva")]
    public string Nombre;
    public string info_mejora;
    public float precio;
    Canvas canvaItem;
    Transform lista;
    bool rellenar;

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
                    Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(69f, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Vida").transform);
                    lista.GetChild(lista.childCount - 1).GetComponent<Image>().fillAmount = 0.5f;
                    collision.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.childCount - 1).GetComponent<Image>());
                    collision.GetComponent<playerAtributtes>().vidaTotal += agregaVida;

                }
                else
                {


                    Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(69f, 0, 0), Quaternion.Euler(0,0,0), GameObject.FindGameObjectWithTag("Vida").transform);
                    collision.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.transform.childCount - 1).GetComponent<Image>());
                    collision.GetComponent<playerAtributtes>().vidaTotal += agregaVida;

                }

                
            }

            Destroy(gameObject);
        }
    }

    public void aplicarItem()
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
                Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(69f, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Vida").transform);
                lista.GetChild(lista.childCount - 1).GetComponent<Image>().fillAmount = 0.5f;
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.childCount - 1).GetComponent<Image>());
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vidaTotal += agregaVida;
                
            }
            else
            {


                Instantiate(imagen, lista.GetChild(lista.childCount - 1).position + new Vector3(69f, 0, 0), Quaternion.Euler(0, 0, 0), GameObject.FindGameObjectWithTag("Vida").transform);
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vida.Add(lista.transform.GetChild(lista.transform.childCount - 1).GetComponent<Image>());
                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerAtributtes>().vidaTotal += agregaVida;

            }


        }

        
    }
}
