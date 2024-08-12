using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanismoPuertas : MonoBehaviour
{
    public bool abrir;
    [SerializeField] GameObject piso;

    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        abrir = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1) 
        {
            if(GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales.Count >= 5)
            {
                if(transform.parent.parent.gameObject != GameObject.FindGameObjectWithTag("Generador").GetComponent<generadorMapa>().habitaciones_Especiales[0].gameObject) 
                {
                    if(piso.GetComponent<colliderPiso>().hayEnemigos == true  && piso.GetComponent<colliderPiso>().estaElJugador == true)
                    {
                        abrir = false;
                    }
                    if(piso.GetComponent<colliderPiso>().estaElJugador == false)
                    {
                        abrir = true;
                    }
                    if(piso.GetComponent<colliderPiso>().hayEnemigos == false && piso.GetComponent<colliderPiso>().estaElJugador == true)
                    {
                        abrir = true;
                    }
                }
                else
                {
                    if (piso.GetComponent<colliderPisoJefe>().hayEnemigos == true && piso.GetComponent<colliderPisoJefe>().estaElJugador == true)
                    {
                        abrir = false;
                    }
                    if (piso.GetComponent<colliderPisoJefe>().estaElJugador == false)
                    {
                        abrir = true;
                    }
                    if (piso.GetComponent<colliderPisoJefe>().hayEnemigos == false && piso.GetComponent<colliderPisoJefe>().estaElJugador == true)
                    {
                        abrir = true;
                    }
                }
            }

            for(int i = 0; i < 4; i++)
            {
                if (!transform.GetChild(i).GetComponent<puertaLibre>().libre)
                {
                    if(abrir)
                    {
                        transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                        transform.GetChild(i).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    }
                   else
                   {
                        transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        transform.GetChild(i).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                   }
                }
                else
                {
                    transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(i).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
            }
        }
        
    }
}
