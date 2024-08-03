using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoAmarillo : MonoBehaviour
{
    [Header("valores")]
    public float velocidad = 3f;
    public float dirreccion;
    float timer;
    float timer_disparo;

    [Header("hueso")]
    public GameObject hueso;
    Rigidbody2D rigid;
    Animator ani;
    Transform jugador;

    float condicion;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        dirreccion = Random.Range(0, 4);
        condicion = Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
        {
            timer += Time.deltaTime;
            
            if(timer >= 4f)
            {
                dirreccion = Random.Range(0, 4);
                timer = 0;
            }

            switch (dirreccion)
            {
                case 0:
                    rigid.velocity = new Vector2(0, velocidad);
                    ani.SetFloat("mov", 2);
                    break;

                case 1:
                    rigid.velocity = new Vector2(0, -velocidad);
                    ani.SetFloat("mov", -2);
                    break;

                case 2:
                    rigid.velocity = new Vector2(velocidad, 0);
                    ani.SetFloat("mov", 1);
                    break;

                case 3:
                    rigid.velocity = new Vector2(-velocidad, 0);
                    ani.SetFloat("mov", -1);
                    break;
            }

            timer_disparo += Time.deltaTime;
            if(timer_disparo >= condicion)
            {
                
                Instantiate(hueso, transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(hueso, transform.position, Quaternion.Euler(0, 0, 90));
                Instantiate(hueso, transform.position, Quaternion.Euler(0, 0, -90));
                Instantiate(hueso, transform.position, Quaternion.Euler(0, 0, 180));
                timer_disparo = 0;
            }

            GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            for (int i = 0; i < listaEnemigos.Length; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
            }


        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Obstaculo") || collision.transform.CompareTag("vacio"))
        {
            switch (dirreccion)
            {
                case 0:
                    dirreccion = 1;
                    timer = 0;
                    break;
                case 1:
                    dirreccion = 0;
                    timer = 0;
                    break;
                case 2:
                    dirreccion = 3;
                    timer = 0;
                    break;
                case 3:
                    dirreccion = 2;
                    timer = 0;
                    break;
            }
        }
    }

}
