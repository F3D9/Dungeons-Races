using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class CompraItem : MonoBehaviour
{
    public TMP_Text textoPrecio;
    public List<GameObject> items = new List<GameObject>();
    float precio;
    
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        int nro = Random.Range(0, items.Count);
        Instantiate(items[nro], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0), transform.GetChild(0));
        precio = items[nro].GetComponent<Items>().precio;
        item = transform.GetChild(0).GetChild(0).gameObject;
        textoPrecio.text = precio.ToString();
        item.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(collision.transform.GetComponent<Sistema>().oro >= precio)
            {
                collision.transform.GetComponent<Sistema>().oro -= precio;

                item.transform.GetComponent<Items>().aplicar();
                
                Destroy(transform.GetChild(0).gameObject);
                Destroy(transform.GetChild(1).gameObject);
            }
        }
    }


}
