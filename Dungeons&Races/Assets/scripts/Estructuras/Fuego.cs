using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [Header("Ajustes")]
    public int modo = 1;
    float probabilidad = 0.15f;
    public RuntimeAnimatorController modo1, modo2, modo3;
    public Sprite piedras;
    public float dañoJugador = 0.5f;
    public int dañoEnemigos = 50;
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
        switch (modo)
        {
            case 1:
                ani.runtimeAnimatorController = modo1;
                break;
            case 2:
                ani.runtimeAnimatorController = modo2;
                break;
            case 3:
                ani.runtimeAnimatorController = modo3;
                break;
            case 4:
                ani.enabled = false;
                ani.runtimeAnimatorController = null;
                GetComponentInChildren<SpriteRenderer>().sprite = piedras;
                transform.GetChild(1).gameObject.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                GameObject.FindGameObjectWithTag("Admin").transform.GetComponent<soltarObjetos>().soltarObjeto(transform.position);
                modo++;
                break;
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
            collision.transform.GetComponent<playerAtributtes>().tomarDaño(dañoJugador);
        }
        if (collision.transform.CompareTag("Enemigo"))
        {
            collision.transform.GetComponent<atributosEnemigos>().tomarDaño(dañoEnemigos, transform.position);
        }
    }

}
