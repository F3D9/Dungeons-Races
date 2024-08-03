using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class volar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aplicarItem();
        }
    }

    public void aplicarItem()
    {
       GameObject.FindGameObjectWithTag("Player").gameObject.layer = 7;
        Destroy(gameObject);
    }
}
