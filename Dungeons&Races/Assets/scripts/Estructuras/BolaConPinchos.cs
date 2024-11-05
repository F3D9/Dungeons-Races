using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaConPinchos : MonoBehaviour
{
    public float velocidad;
    int nro;

    // Start is called before the first frame update
    void Start()
    {
        nro = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
        {
            GetComponent<Animator>().enabled = true;
            switch (nro)
            {
                case 0:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, 0);
                    break;

                case 1:
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidad);
                    break;
            }
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            velocidad = -velocidad;
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDaño(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        velocidad = -velocidad;
    }
}
