using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acido_verde : MonoBehaviour
{
    [Header("Ajustes")]
    public int id;
    public float daño = 0.5f;
    public float tiempo_de_vida = 1.5f;

    enum objetivo
    {
        jugador,
        enemigos
    }

    [SerializeField] objetivo quienRecibeDaño = objetivo.jugador;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("morir", false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("animacion", tiempo_de_vida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GetComponent<Animator>().GetBool("morir") == false)
        {
            switch (quienRecibeDaño)
            {
                case(objetivo.jugador):
                    if (collision.CompareTag("Player") && collision != collision.GetComponent<PolygonCollider2D>())
                    {
                        if(collision.GetComponent<Sistema>().apariencia != id)
                        {
                            collision.GetComponent<playerAtributtes>().tomarDaño(daño);
                        }
                
                    }
                    break;

                case (objetivo.enemigos):
                    if (collision.CompareTag("Enemigo"))
                    {
                        collision.GetComponent<atributosEnemigos>().tomarDañoSlime(daño);
                    }
                    break;
            }
            
        }
        
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

    public void animacion()
    {
        GetComponent<Animator>().SetBool("morir", true);
    }


}
