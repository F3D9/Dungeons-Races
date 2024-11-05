using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class snakeMoves : MonoBehaviour
{
    enum States
    {
        quiet,
        move,
        shoot,
        spawnChild,
    }

    [SerializeField] States actualState;

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

    Transform jugador;
    Animator ani;
    int nroLugar;
    float timer;


    Rigidbody2D rigid;
    NavMeshAgent enemigo;


    // Start is called before the first frame update
    void Start()
    {
        actualState = States.quiet;
        barra_vida.gameObject.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GetComponent<Animator>();
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

            GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            for (int i = 0; i < listaEnemigos.Length; i++)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
            }

            switch (actualState)
            {
                case States.quiet:
                    enemigo.enabled = false;
                    ani.SetFloat("mov", 0);
                    //Chose new spot
                    nroLugar = Random.Range(0, lugares.Count);
                    actualState = States.move;
                    break;

                case States.move:
                    //If is already in the spot
                    if (transform.position == lugares[nroLugar].position)
                    {
                        int ac = Random.Range(1, 3);
                        switch (ac) 
                        {
                            case 1:
                                actualState  = States.shoot;
                                break;

                            case 2:
                                actualState = States.spawnChild;
                                break;
                        }

                    }
                    else
                    {
                        //move to the defined spot
                        enemigo.enabled = true;
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

                case States.shoot:
                    timer += Time.deltaTime;
                    if( timer > 5)
                    {
                        actualState = States.quiet;
                        timer = 0;
                    }
                    else
                    {
                        if (jugador.position.x >= transform.position.x)
                        {
                            ani.SetFloat("mov", 2);
                        }
                        else
                        {
                            ani.SetFloat("mov", -2);
                        }
                    }
                    
                    break;

                case States.spawnChild:
                    Instantiate(serpiente, transform.position, Quaternion.Euler(0, 0, 0), transform.parent);
                    Instantiate(humo, transform.position, Quaternion.Euler(0, 0, 0));
                    piso.GetComponent<colliderPisoJefe>().jefes.Add(transform.parent.GetChild(transform.parent.childCount - 1).gameObject);
                    actualState = States.quiet;
                    break;
            }


        }
        else
        {
            ani.enabled = false;
            enemigo.enabled = false;
        }

    }

    public void dispararMisil()
    {
        float anguloRadianes = Mathf.Atan2(jugador.position.y - transform.position.y, jugador.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;

        Instantiate(bullet, spawnBalas.position, Quaternion.Euler(0, 0, anguloGrados));

        
    }


}
