using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class colliderPisoJefe : MonoBehaviour
{
    public List<GameObject> jefes = new List<GameObject>();
    public bool hayEnemigos;
    public bool estaElJugador;
    int numero;


    // Start is called before the first frame update
    void Awake()
    {
        estaElJugador = false;
        hayEnemigos = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaElJugador == true)
        {
      
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }

        numero = 0;

        for (int i = 0; i < jefes.Count; i++)
        {
            if (jefes[i] != null)
            {
                hayEnemigos = true;
            }
            else
            {
                numero++;
            }
        }
        
        if(numero == jefes.Count)
        {
            hayEnemigos = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            estaElJugador = true;
        }

        if (collision.tag == "Enemigo")
        {
            hayEnemigos = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            hayEnemigos = false;
        }

        if (collision.tag == "Player")
        {
            estaElJugador = false;
        }
    }
}
