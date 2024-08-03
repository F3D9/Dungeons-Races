using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaJefe : MonoBehaviour
{
    [Header("Valores")]
    public float vida = 4000;
    [SerializeField] float vidaTotal;
    [SerializeField] float daño = 0.5f;
    [SerializeField] float distancia = 2f;
    [SerializeField] GameObject cadaver;
    [SerializeField] int score;

    [Header("Barra de Vida")]
    [SerializeField] Canvas barrita;
    [SerializeField] Image barra_de_vida;


    // Start is called before the first frame update
    void Start()
    {
        vidaTotal = vida;
    }

    // Update is called once per frame
    void Update()
    {
        barra_de_vida.fillAmount = vida / vidaTotal;
       

        if (vida <= 0)
        {
            Instantiate(cadaver, transform.position, transform.rotation);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Destroy(gameObject);
        }

        //bloqueo la rotacion de los enemigos
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void tomarDaño(float daño)
    {
        vida -= daño;

        transform.Translate(new Vector2(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) * distancia * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<playerAtributtes>().tomarDaño(daño);
        }
    }
}
