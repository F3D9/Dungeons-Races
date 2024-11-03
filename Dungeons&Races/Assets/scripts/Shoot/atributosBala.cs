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

    [Header("VFX")]
    [SerializeField] GameObject vfx;

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
            Instantiate(vfx, transform.position, transform.rotation);
            destruir();
            //GetComponent<Animator>().SetBool("Caida", true);
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
                Instantiate(vfx, transform.position, transform.rotation);
                destruir();
                
            }
        }

        if(collision.tag == "Enemigo")
        {
            collision.GetComponent<atributosEnemigos>().tomarDaño(daño,transform.position);
            Instantiate(vfx, transform.position, transform.rotation);
            collisionesContador();
        }

        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<vidaJefe>().tomarDaño(daño);
            collisionesContador();
        }

        
        if (collision.tag == "Obstaculo")
        {
            Instantiate(vfx, transform.position, transform.rotation);
            destruir();
        }
    }

    void collisionesContador()
    {
        if(colisiones == choque_con_objetivos)
        {
            Instantiate(vfx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            colisiones++;
        }
    }


}
