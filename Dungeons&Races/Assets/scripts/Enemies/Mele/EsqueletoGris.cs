using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EsqueletoGris : MonoBehaviour
{

    [SerializeField] int aparenciaFreeze;
    [SerializeField] Animator ani;

    NavMeshAgent enemigo;
    Rigidbody2D rb;
    Transform jugador;

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponentInChildren<NavMeshAgent>();
        enemigo.updateRotation = false;
        enemigo.updateUpAxis = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").gameObject.activeInHierarchy == true)
        {
            if (transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true && jugador.GetComponent<Sistema>().apariencia != aparenciaFreeze)
            {
                GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemigo");

                for (int i = 0; i < listaEnemigos.Length; i++)
                {
                    Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), listaEnemigos[i].GetComponent<BoxCollider2D>());
                }

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
                

            }
            else
            {
                enemigo.enabled = false;
                ani.enabled = false;
            }
             

        }

    }

    


}
