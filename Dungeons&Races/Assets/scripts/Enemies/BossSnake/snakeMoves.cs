using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class snakeMoves : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] float velocidad = 4f;
    [SerializeField] GameObject serpiente;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject piso;

    [Header("Disparo")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnBalas;
    [SerializeField] List<Transform> lugares = new List<Transform>();
    [SerializeField] Canvas barra_vida;
    int nro;
    Transform jugador;
    Animator ani;
    int nroLugar;

    Rigidbody2D rigid;
    NavMeshAgent enemigo;

    float timer;
    float timer2;

    // Start is called before the first frame update
    void Start()
    {
        barra_vida.gameObject.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GetComponent<Animator>();
        nro = 0;
        rigid = GetComponent<Rigidbody2D>();

        enemigo = GetComponent<NavMeshAgent>();
        enemigo.updateRotation = false;
        enemigo.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPisoJefe>().estaElJugador == true)
        {
            ani.enabled = true;
            barra_vida.gameObject.SetActive(true);
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
            switch (nro)
            {
                case 0:
                    enemigo.enabled = true;
                    nroLugar = Random.Range(0, lugares.Count);
                    
                    nro = Random.Range(1, 3);
                    break;

                case 1:
                    if(transform.position == lugares[nroLugar].position)
                    {
                        if(timer <= 5f)
                        {
                            if (jugador.position.x > transform.position.x)
                            {
                                ani.SetFloat("mov", 2);
                            }
                            else
                            {
                                ani.SetFloat("mov", -2);
                            }
                            timer += Time.deltaTime;
                        }
                        else
                        {
                            nro = 0;
                            timer = 0;
                        }
                        
                    }
                    else
                    {
                        enemigo.SetDestination(lugares[nroLugar].position);
                        if (lugares[nroLugar].transform.position.x >= transform.position.x)
                        {
                            ani.SetFloat("mov", 1);
                        }
                        else
                        {
                            ani.SetFloat("mov", -1);
                        }
                    }
                    
                    break;

                case 2:
                    if (transform.position == lugares[nroLugar].position)
                    {
                        Instantiate(serpiente, transform.position, Quaternion.Euler(0, 0, 0),transform.parent);
                        Instantiate(humo, transform.position, Quaternion.Euler(0, 0, 0));
                        piso.GetComponent<colliderPisoJefe>().jefes.Add(transform.parent.GetChild(transform.parent.childCount - 1).gameObject);
                        nro = 0;

                    }
                    else
                    {
                        enemigo.SetDestination(lugares[nroLugar].position);
                        if (lugares[nroLugar].transform.position.x >= transform.position.x)
                        {
                            ani.SetFloat("mov", 1);
                        }
                        else
                        {
                            ani.SetFloat("mov", -1);
                        }
                    }
                    break;
            }
            GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            for (int i = 0; i < listaEnemigos.Length; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
            }

        }
        else
        {
            ani.enabled = false;
        }
    }

    public void dispararMisil()
    {
        float anguloRadianes = Mathf.Atan2(jugador.position.y - transform.position.y, jugador.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;

        Instantiate(bullet, spawnBalas.position, Quaternion.Euler(0, 0, anguloGrados));
        
    }

}
