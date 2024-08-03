using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributosEnemigos : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] float vida = 100;
    [SerializeField] float daño = 0.5f;
    [SerializeField] float distancia = 2f;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] int score;

    [Header("Muerte")]

    public GameObject cadaver;
    public AudioClip sonidoMuerte;

    bool dañoSlime = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Instantiate(cadaver, transform.position, Quaternion.Euler(0,0,0));
            SonidoControler.Instance.ejecutarSonido(sonidoMuerte);
            Destroy(gameObject);

            
        }

        //bloqueo la rotacion de los enemigos
        transform.rotation = Quaternion.Euler(0, 0,0);

        if (dañoSlime)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                dañoSlime=false;
                timer = 0;
            }
        }
    }

    public void tomarDaño(float daño,Vector3 alejarse)
    {
        vida -= daño;
        spriteR.color = Color.red;
        transform.Translate(new Vector2(transform.position.x - alejarse.x, transform.position.y - alejarse.y) * distancia * Time.deltaTime);
        Invoke("volverColor", 0.1f);
    }

    public void tomarDañoSlime(float daño)
    {
        if (!dañoSlime) 
        {
            vida -= daño;
            spriteR.color = Color.red;
            Invoke("volverColor", 0.1f);
            dañoSlime= true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDaño(daño);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDaño(daño);

        }
    }

    void volverColor()
    {
        spriteR.color = Color.white;
    }
}
