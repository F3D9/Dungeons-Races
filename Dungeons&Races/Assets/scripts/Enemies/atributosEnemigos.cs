using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atributosEnemigos : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] float vida = 100;
    [SerializeField] float da�o = 0.5f;
    [SerializeField] float distancia = 2f;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] int score;

    [Header("Muerte")]

    public GameObject cadaver;
    public AudioClip sonidoMuerte;

    bool da�oSlime = false;
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

        if (da�oSlime)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                da�oSlime=false;
                timer = 0;
            }
        }
    }

    public void tomarDa�o(float da�o,Vector3 alejarse)
    {
        vida -= da�o;
        spriteR.color = Color.red;
        transform.Translate(new Vector2(transform.position.x - alejarse.x, transform.position.y - alejarse.y) * distancia * Time.deltaTime);
        Invoke("volverColor", 0.1f);
    }

    public void tomarDa�oSlime(float da�o)
    {
        if (!da�oSlime) 
        {
            vida -= da�o;
            spriteR.color = Color.red;
            Invoke("volverColor", 0.1f);
            da�oSlime= true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDa�o(da�o);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDa�o(da�o);

        }
    }

    void volverColor()
    {
        spriteR.color = Color.white;
    }
}
