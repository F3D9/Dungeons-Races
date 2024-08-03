using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilEnemigo : MonoBehaviour
{
    [Header("Parametros")]
    public float velocidad;
    public float daño;
    public float rango;
    public int id;
    public GameObject sombra;
    float timer;

    Vector3 objetivo = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Instantiate(sombra, transform.position, Quaternion.Euler(0, 0, 0), transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        
        timer += Time.deltaTime;

        if (timer >= rango)
        {
            GetComponent<Animator>().SetBool("Caida", true);
        }
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(id == 2 && collision.GetComponent<Sistema>().apariencia == 2 || id==1 && collision.GetComponent<Sistema>().apariencia == 4 || id==5 && collision.GetComponent<Sistema>().apariencia == 3)
            {
                
            }
            else
            {
                collision.GetComponent<playerAtributtes>().tomarDaño(daño);
            }
            

            Destroy(gameObject);
        }

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Obstaculo")
        {
            Destroy(gameObject);
        }

        
    }
}
