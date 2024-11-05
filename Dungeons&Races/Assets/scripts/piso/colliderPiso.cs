using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderPiso : MonoBehaviour
{
    public GameObject spawns;
    public bool mejora;

    public bool hayEnemigos;
    public bool estaElJugador;
    [SerializeField] bool cambiarPiso = true;
    [SerializeField] List<Sprite> pisos = new List<Sprite>();

    
    int numero;

    // Start is called before the first frame update
    void Start()
    {
        if (cambiarPiso)
        {
            int nro = Random.Range(0, pisos.Count);
            GetComponent<SpriteRenderer>().sprite = pisos[nro];
        }

        //Invoke("cargarSpawn", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(estaElJugador == true)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z);
            
        }
        if (!mejora && spawns != null)
        {
            numero = 0;

            for (int i = 0; i < spawns.transform.childCount; i++)
            {
                if (spawns.transform.GetChild(i).childCount >= 1)
                {
                    hayEnemigos = true;
                }
                else
                {
                    numero++;
                }
            }

            if(numero == spawns.transform.childCount)
            {
                hayEnemigos = false;
            }
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            estaElJugador = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            estaElJugador = false;
        }
    }

    void cargarSpawn()
    {
        spawns = transform.parent.parent.parent.GetChild(1).GetChild(0).GetChild(1).gameObject;
    }

}
