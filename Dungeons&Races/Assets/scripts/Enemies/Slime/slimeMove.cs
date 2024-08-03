using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class slimeMove : MonoBehaviour
{
    Rigidbody2D rigid;

    [Header("Movimiento")]
    [SerializeField] float velocidad = 2;
    [SerializeField] float vertical = 2f;
    [SerializeField] float horizontal = 2f;
    

    [Header("Prefabs")]
    [SerializeField] GameObject moco;
    [SerializeField] float condicion = 0.1f;
    float aparicion;
    [SerializeField] int rutina;
    float timer;
    float giro;
    List<int> lista_numeros = new List<int>();
    bool hitUp, hitDown, hitLeft,hitRight;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rutina = Random.Range(0, 4);
        lista_numeros.Add(Random.Range(0, 4));
        lista_numeros.Add(Random.Range(0, 4));
        lista_numeros.Add(Random.Range(0, 4));
        lista_numeros.Add(rutina);
        giro = Random.Range(0.3f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
        {
            rigid.velocity = new Vector2(horizontal,vertical);

            hitUp = CheckRaycastCollision(Vector2.up);
            hitDown = CheckRaycastCollision(Vector2.down);
            hitLeft = CheckRaycastCollision(Vector2.left);
            hitRight = CheckRaycastCollision(Vector2.right);

            

            GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            for (int i = 0; i < listaEnemigos.Length; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
            }

            timer += Time.deltaTime;

            if (timer >= giro)
            {
                rutina = Random.Range(0, 4);
                bool bucle = false;
                while (!bucle)
                {
                    if (rutina == lista_numeros[2] || rutina == lista_numeros[3])
                    {
                        rutina = Random.Range(0, 4);
                    }
                    else
                    {
                        lista_numeros.RemoveAt(0);
                        lista_numeros.Add(rutina);
                        timer = 0;
                        break;
                    }
                }
            }

            if (lista_numeros[0] == lista_numeros[2] && lista_numeros[1] == lista_numeros[3])
            {
                rutina = Random.Range(0, 4);
                bool bucle = false;
                while (!bucle)
                {
                    if (rutina == lista_numeros[2] || rutina == lista_numeros[3])
                    {
                        rutina = Random.Range(0, 4);
                    }
                    else
                    {
                        lista_numeros.RemoveAt(0);
                        lista_numeros.Add(rutina);
                        timer = 0;
                        break;
                    }
                }
            }
            

            switch (rutina)
            {
                case 0:
                    vertical = velocidad;
                    horizontal = 0f;
                    GetComponent<Animator>().SetFloat("slime", 2);
                    break;
                case 1:
                    vertical = -velocidad;
                    horizontal = 0f;
                    GetComponent<Animator>().SetFloat("slime", -2);
                    break;
                case 2:
                    vertical = 0f;
                    horizontal = velocidad;
                    GetComponent<Animator>().SetFloat("slime", 1);
                    break;
                case 3:
                    vertical = 0f;
                    horizontal = -velocidad;
                    GetComponent<Animator>().SetFloat("slime", -1);
                    break;
                case 4:
                    GetComponent<Animator>().SetFloat("slime", 0);
                    break;
            }
        }
        

    }

    private void FixedUpdate()
    {
        if(transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
        {
            aparicion += Time.deltaTime;
            if(aparicion >= condicion && moco != null)
            {
                Instantiate(moco,transform.GetChild(0).position,transform.GetChild(0).rotation,GameObject.FindGameObjectWithTag("manchas").transform);
                aparicion = 0;
            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Wall"))
        {
            rutina = Random.Range(0, 4);
            bool bucle = false;
            while (!bucle)
            {
                if(rutina == lista_numeros[2] || rutina == lista_numeros[3])
                {
                    rutina = Random.Range(0, 4);
                }
                else
                {
                    lista_numeros.RemoveAt(0);
                    lista_numeros.Add(rutina);
                    timer = 0;
                    giro = Random.Range(0.3f, 1.5f);
                    break;
                }
            }
        }
        


    }

    bool CheckRaycastCollision(Vector2 direction)
    {
        // Origen del rayo (posición actual del enemigo)
        Vector2 origin = transform.position;

        // Longitud del rayo
        float distance = 1f;

        // Realiza el Raycast en la dirección especificada
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance);

        // Comprueba si el rayo golpea algo
        return hit.collider != null;
    }





}
