using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [Header("Ajustes")]
    public int modo = 1;
    float probabilidad = 0.15f;
    public RuntimeAnimatorController modo1, modo2, modo3;
    public Sprite piedras;
    public float da�oJugador = 0.5f;
    public int da�oEnemigos = 50;
    Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPiso>().estaElJugador == true)
        {
            ani.enabled = true;
            

            switch (modo)
            {
                case 1:
                    ani.runtimeAnimatorController = modo1;
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 2:
                    ani.runtimeAnimatorController = modo2;
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 3:
                    ani.runtimeAnimatorController = modo3;
                    transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 4:
                    ani.enabled = false;
                    ani.runtimeAnimatorController = null;
                    GetComponentInChildren<SpriteRenderer>().sprite = piedras;

                    //Off the light
                    transform.GetChild(1).gameObject.SetActive(false);

                    //Stop loop in particle system
                    var main = transform.GetChild(2).GetComponent<ParticleSystem>().main;
                    main.loop = false;

                    GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.FindGameObjectWithTag("Admin").transform.GetComponent<soltarObjetos>().soltarObjeto(transform.position);
                    modo++;
                    break;
            }
        }
        else
        {
            ani.enabled=false;
            transform.GetChild(2).gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            modo ++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDa�o(da�oJugador);
        }
        if (collision.transform.CompareTag("Enemigo"))
        {
            collision.transform.GetComponent<atributosEnemigos>().tomarDa�o(da�oEnemigos, transform.position);
        }
    }

}
