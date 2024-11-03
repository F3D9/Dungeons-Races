using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.AI;

public class GreenAlien : MonoBehaviour
{
    [SerializeField] int aparenciaFreeze;
    [SerializeField] Animator ani;

    public float invisible_duration;
    public float make_invisible;

    public float makeInvisibleTimer;
    public float disableInvisibleTimer;

    bool alreadyInvisible;
    public bool transition;

    NavMeshAgent enemigo;
    Rigidbody2D rb;
    Transform jugador;

    enum state
    {
        quiet,
        chasing,
        invisibleON,
        invisibleOFF,
    }

    state actualState = new state();

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponentInChildren<NavMeshAgent>();
        enemigo.updateRotation = false;
        enemigo.updateUpAxis = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        make_invisible = Random.Range(2.5f, 6);
        invisible_duration = Random.Range(6, 12);
        transition = false;
        alreadyInvisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").gameObject.activeInHierarchy == true)
        {
            if (transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true && jugador.GetComponent<Sistema>().apariencia != aparenciaFreeze)
            {
                GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

                for (int i = 0; i < listaEnemigos.Length; i++)
                {
                    Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
                }

                //If enemy is making a transition no change the states
                if (!transition)
                {
                    //if the enemy already do the invisible animation
                    if (!alreadyInvisible)
                    {
                        //no change to invisible yet
                        makeInvisibleTimer += Time.deltaTime;
                        

                        if (makeInvisibleTimer >= make_invisible)
                        {
                            actualState = state.invisibleON;
                        }
                        else
                        {
                            actualState = state.chasing;
                        }
                    }
                    else
                    {
                        //already invisible
                        disableInvisibleTimer += Time.deltaTime;
                        

                        if (disableInvisibleTimer >= invisible_duration)
                        {
                            actualState = state.invisibleOFF;
                        }
                        else
                        {
                            actualState = state.chasing;
                        }
                    }
                }
                
                
                


            }
            else
            {
                actualState = state.quiet;
            }


        }


        switch (actualState)
        {
            case state.quiet:

                enemigo.enabled = false;
                ani.enabled = false;
                break;

            case state.chasing:

                enemigo.enabled = true;
                enemigo.SetDestination(jugador.position);
                ani.enabled = true;

                if (transform.position.x > jugador.position.x)
                {
                    ani.SetFloat("horizontal", 1);
                }
                if (transform.position.x < jugador.position.x)
                {
                    ani.SetFloat("horizontal", -1);
                }
                break;

            case state.invisibleON:

                enemigo.enabled = false;
                transition = true;
                ani.SetFloat("horizontal", 0.5f);
                alreadyInvisible = true;
                disableInvisibleTimer = 0;
                break;

            case state.invisibleOFF:

                enemigo.enabled = false;
                transition = true;
                ani.SetFloat("horizontal", 0.5f);
                alreadyInvisible = false;
                makeInvisibleTimer = 0;
                break;
        }

    }


}
