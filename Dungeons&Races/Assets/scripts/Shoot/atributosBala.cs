using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributosBala : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] AudioClip sonido;

    [Header("Sombra")]
    public GameObject sombra;

    [Header("Parametros")]
    [SerializeField] float velocidad;
    public float daño;
    [SerializeField] float rango;
    [SerializeField] int choque_con_objetivos;
    int colisiones;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        SonidoControler.Instance.ejecutarSonido(sonido);
        Instantiate(sombra, transform.position, Quaternion.Euler(0, 0, 0), transform);
        colisiones = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);

        timer += Time.deltaTime;

        if(timer >= rango)
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
        if(timer>= 0.15f)
        {
            if(collision.tag == "Wall")
            {
                destruir();
                
            }
        }

        if(collision.tag == "Enemigo")
        {
            collision.GetComponent<atributosEnemigos>().tomarDaño(daño,transform.position);

            collisionesContador();
        }

        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<vidaJefe>().tomarDaño(daño);
            collisionesContador();
        }

        
        if (collision.tag == "Obstaculo")
        {
            destruir();
        }
    }

    void collisionesContador()
    {
        if(colisiones == choque_con_objetivos)
        {
            Destroy(gameObject);
        }
        else
        {
            colisiones++;
        }
    }


}
