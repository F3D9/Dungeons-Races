using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movDistancia : MonoBehaviour
{
    NavMeshAgent enemigo;
    Transform jugador;
    float timer;
    float anguloRadianes;
    float anguloGrados;

    [Header("Variables")]
    [SerializeField] float rango = 5f;
    [SerializeField] float tiempo_para_disparar = 1.5f;
    [SerializeField] float distancia = 0.4f;

    [Header("Atacar")]
    [SerializeField] GameObject misil;

    Vector3 lugarJugador = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<NavMeshAgent>();
        enemigo.updateRotation = false;
        enemigo.updateUpAxis = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").gameObject.activeInHierarchy == true)
        {
            if (transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
            {
                
                RaycastHit2D hitArriba = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + distancia), jugador.position - transform.position,rango);
                RaycastHit2D hitAbajo = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - distancia), jugador.position - transform.position, rango);
                
                if (hitArriba.collider != null && hitAbajo.collider != null)
                {
                    if (hitArriba.collider.CompareTag("Player") && hitAbajo.collider.CompareTag("Player"))
                    {
                        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + distancia), jugador.position - transform.position, Color.red);
                        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - distancia), jugador.position - transform.position, Color.red);
                        GetComponent<Animator>().enabled = true;
                        enemigo.enabled = false;
                        if (jugador.position.x < transform.position.x)
                        {
                            GetComponent<Animator>().SetFloat("horizontal", 0.5f);

                        }
                        else
                        {
                            GetComponent<Animator>().SetFloat("horizontal", 0);
                        }


                    }
                    else
                    {
                        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + distancia), jugador.position - transform.position, Color.blue);
                        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - distancia), jugador.position - transform.position, Color.blue);


                        enemigo.enabled = true;
                        enemigo.SetDestination(jugador.position);
                        GetComponent<Animator>().enabled = true;
                        if (transform.position.x > jugador.position.x)
                        {
                            GetComponent<Animator>().SetFloat("horizontal", 1);
                        }
                        if (transform.position.x < jugador.position.x)
                        {
                            GetComponent<Animator>().SetFloat("horizontal", -1);
                        }
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, jugador.position - transform.position, Color.blue);
                    enemigo.enabled = true;
                    enemigo.SetDestination(jugador.position);
                    GetComponent<Animator>().enabled = true;
                    if (transform.position.x > jugador.position.x)
                    {
                        GetComponent<Animator>().SetFloat("horizontal", 1);
                    }
                    if (transform.position.x < jugador.position.x)
                    {
                        GetComponent<Animator>().SetFloat("horizontal", -1);
                    }
                }
                


            }
            else
            {
                enemigo.enabled = false;
                GetComponent<Animator>().enabled = false;
            }

            anguloRadianes = Mathf.Atan2(jugador.position.y - transform.position.y, jugador.position.x - transform.position.x);

            anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

            GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            for (int i = 0; i < listaEnemigos.Length; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
            }

        }
    }

    

    public void tirar_misil()
    {
        Instantiate(misil, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }

    public void lugarDelJugador()
    {
        lugarJugador = jugador.position;
    }

    public void salto()
    {
        enemigo.enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForceAtPosition((lugarJugador- transform.position), lugarJugador,ForceMode2D.Impulse);
        
    }

    public void volver_normalidad()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        enemigo.enabled = true;
        
    }

}
