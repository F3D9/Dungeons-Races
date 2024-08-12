using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class volar : MonoBehaviour
{

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
