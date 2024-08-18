using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EsqueletoGris : MonoBehaviour
{

    [SerializeField] int aparenciaFreeze;

    NavMeshAgent enemigo;
    Transform jugador;

    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponentInChildren<NavMeshAgent>();
        enemigo.updateRotation = false;
        enemigo.updateUpAxis = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
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
            else
            {
                enemigo.enabled = false;
                GetComponent<Animator>().enabled = false;
            }
             

        }

    }


}
