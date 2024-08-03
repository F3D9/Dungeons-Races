using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

using UnityEngine;
using UnityEngine.UI;

public class bossKnight : MonoBehaviour
{
    [Header("valores")]
    public float velocidad;
    public float velocidadNormal = 3.5f;
    public float velocidadEnojado = 6f;
    float persecuccion = 5f;
    float timer;
    float timer2;
    public int nro;
    bool tranformacion;

    [Header("Prefabs")]
    public GameObject municion1;
    public GameObject municion2;
    public Canvas barra_vida;
    public RuntimeAnimatorController verde;
    public RuntimeAnimatorController rojo;
    Rigidbody2D rigi;
    Transform jugador;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = velocidadNormal;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rigi = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        barra_vida.gameObject.SetActive(false);
        nro = Random.Range(0, 3);
        tranformacion = false;
        ani.runtimeAnimatorController = verde;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.parent.GetChild(0).GetChild(0).GetComponentInChildren<colliderPisoJefe>().estaElJugador == true)
        {
            if (GetComponent<vidaJefe>().vida >= 2000)
            {
                barra_vida.gameObject.SetActive(true);
                barra_vida.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;

                switch (nro)
                {
                    case 0:
                        ani.SetBool("Jump", false);
                        ani.SetBool("Shoot", false);
                        
                        timer2 += Time.deltaTime;
                        if (timer2 >= persecuccion)
                        {
                            ani.SetFloat("move", 2);
                            Invoke("resetTime", 3f);
                        }
                        else
                        {
                            if (jugador.position.x >= transform.position.x)
                            {
                                
                                ani.SetFloat("move", 1);
                                transform.Translate(new Vector3(jugador.position.x - transform.position.x, jugador.position.y - transform.position.y, 0) * Time.deltaTime * velocidad);
                            }
                            else
                            {
                                
                                ani.SetFloat("move", -1);
                                transform.Translate(new Vector3(jugador.position.x - transform.position.x, jugador.position.y - transform.position.y, 0) * Time.deltaTime * velocidad);
                            }
                        }
                        break;

                    case 1:
                        ani.SetBool("Shoot", false);
                        ani.SetFloat("move", 0);
                        ani.SetBool("Jump", true);
                        
                        break;
                        
                        

                    case 2:
                        timer += Time.deltaTime;
                        if (timer < 4)
                        {
                            ani.SetFloat("move", 0);
                            ani.SetBool("Jump", false);
                            ani.SetBool("Shoot", true);
                            
                        }
                        else
                        {
                            resetTime();
                        }

                        break;

                }

            }
            if( GetComponent<vidaJefe>().vida > 0 && GetComponent<vidaJefe>().vida < 2000)
            {
                if(tranformacion == false)
                {
                    ani.SetFloat("move", 0);
                    ani.SetBool("Jump", false);
                    ani.SetBool("Shoot", false);
                    ani.SetBool("Transform", true);
                    velocidad = 0;
                }
                else
                {
                    barra_vida.gameObject.SetActive(true);
                    barra_vida.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
                    velocidad = velocidadEnojado;

                    switch (nro)
                    {
                        case 0:
                        
                            ani.SetBool("Shoot", false);
                            ani.SetBool("Jump", false);
                            timer += Time.deltaTime;
                            if(timer < 2)
                            {
                                if (jugador.position.x >= transform.position.x)
                                {
                                    ani.SetFloat("move", 1);
                                    transform.Translate(new Vector3(jugador.position.x - transform.position.x, jugador.position.y - transform.position.y, 0) * velocidad * Time.deltaTime);
                                }
                                else
                                {
                                    ani.SetFloat("move", -1);
                                    transform.Translate(new Vector3(jugador.position.x - transform.position.x, jugador.position.y - transform.position.y, 0) * velocidad * Time.deltaTime);
                                }
                            }
                            else
                            {
                                resetTime();
                            }
                        
                        
                            break;

                        case 1:
                            timer += Time.deltaTime;
                            if (timer < 3)
                            {
                            
                                ani.SetFloat("move", 0);
                                ani.SetBool("Shoot", false);
                                ani.SetBool("Jump", true);
                            
                            }
                            else
                            {
                                resetTime();
                            }
                            break;

                        case 2:
                            timer += Time.deltaTime;
                            if(timer < 3)
                            {
                                ani.SetFloat("move", 0);
                                ani.SetBool("Jump", false);
                                ani.SetBool("Shoot", true);
                            }
                            else
                            {
                                resetTime();
                            }
                        
                            break;

                    }
                }
                
                
                
            }
            if (GetComponent<vidaJefe>().vida == 0)
            {
                barra_vida.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        else
        {
            barra_vida.gameObject.SetActive(false);
            nro = 0;
            timer2 = 0;
        }
        
    }

    void disparo1()
    {
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 45));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 135));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 225));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 270));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 315));
        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, 360));
    }

    void disparo1Red()
    {
        
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 45));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 135));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 225));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 270));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 315));
        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, 360));
    }
    
    void saltoArribaPosicion()
    {
        transform.position = new Vector3(jugador.position.x, transform.position.y, 0);
    }

    void resetTime()
    {
        nro = Random.Range(0, 3);
        timer = 0;
        timer2 = 0;
    }


    void redON()
    {
        tranformacion = true;
        ani.runtimeAnimatorController = rojo;
        resetTime();
    }

    void disparo2()
    {
        float anguloRadianes = Mathf.Atan2(jugador.position.y - transform.position.y, jugador.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;

        Instantiate(municion1, transform.position, Quaternion.Euler(0, 0, anguloGrados));

    }

    void disparo2Red()
    {
        float anguloRadianes = Mathf.Atan2(jugador.position.y - transform.position.y, jugador.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;

        Instantiate(municion2, transform.position, Quaternion.Euler(0, 0, anguloGrados));

    }

}
