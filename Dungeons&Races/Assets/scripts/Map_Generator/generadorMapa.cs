using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class generadorMapa : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject habitacion;
    public GameObject habitacionRoja;
    public GameObject habitacionAmarilla;
    public GameObject habitacionAzul;
    public GameObject habitacionVerde;
    public GameObject habitacionVioleta;

    [Header("Generar Habitaciones")]
    public int nivel = 1;
    int cantidad_habitaciones;
    public List<GameObject> habitacionesCreadas = new List<GameObject>();

    int numeroAleatorio;
    int o = 0;

    List<GameObject> listapuertas = new List<GameObject>();
    
    [Header("Habitaciones")]
    public List<GameObject> habitaciones_Especiales = new List<GameObject>();
    public GameObject habitacion_Jefe;
    public GameObject habitacion_SubJefe;
    public GameObject habitacion_mejora;
    public GameObject habitacion_probabilidad;
    public GameObject habitacion_violeta;

    [Header("Obstaculos")]
    public List<GameObject> obsta = new List<GameObject>();

    [Header("Enemigos")]
    public List<GameObject> enemigos_nivel1 = new List<GameObject>();
    public List<GameObject> enemigos_nivel2 = new List<GameObject>();
    public List<GameObject> enemigos_nivel3 = new List<GameObject>();
    int posicion;
    bool no_parar_bucle = true;
    bool es_especial = false;
    int numero;


    // Start is called before the first frame update
    void Awake()
    {
        

        switch (nivel)
        {
            case 1:
                cantidad_habitaciones = Random.Range(15, 20);
                break;
            case 2:
                cantidad_habitaciones = Random.Range(15, 20);
                
                break;
            case 3:
                cantidad_habitaciones = Random.Range(25, 30);
                break;
        }

        GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(true);

        GenerarMapa();
        
        Invoke("seleccionar_habitaciones_sin_salida", 0.12f);
        Invoke("seleccionarHabitacionesEspeciales", 0.15f);
        Invoke("reemplazar_habitaciones_especiales", 0.17f);
        Invoke("generarObstaculos", 0.2f);
        Invoke("generar_enemigos", 0.23f);
        Invoke("borrarPuertas", 0.27f);
        Invoke("sacarPantalladeCarga", 0.3f);
        
    }

    void GenerarMapa()
    {

        habitacionesCreadas.Add(transform.GetChild(0).GetChild(0).gameObject);
        habitacionesCreadas[0].transform.parent.name = "" + o;
        o++;

        numeroAleatorio = Random.Range(0, 4);

        // Segunda habitacion

        switch (numeroAleatorio)
        {
            case 0:
                //ARRIBA
                Instantiate(habitacion, transform);
                habitacionesCreadas.Add(transform.GetChild(1).GetChild(0).gameObject);
                habitacionesCreadas[1].transform.position = new Vector3(habitacionesCreadas[0].transform.position.x, habitacionesCreadas[0].transform.position.y + 10f, 0);
                habitacionesCreadas[1].transform.parent.name = "" + o;
                o++;
                habitacionesCreadas[0].GetComponent<vecinos>().vecino_arriba = habitacionesCreadas[1].gameObject;
                habitacionesCreadas[1].GetComponent<vecinos>().vecino_abajo = habitacionesCreadas[0].gameObject;
                break;

            case 1:
                //IZQUIERDA
                Instantiate(habitacion, transform);
                habitacionesCreadas.Add(transform.GetChild(1).GetChild(0).gameObject);
                habitacionesCreadas[1].transform.position = new Vector3(habitacionesCreadas[0].transform.position.x - 20f, habitacionesCreadas[0].transform.position.y, 0);
                habitacionesCreadas[1].transform.parent.name = "" + o;
                o++;
                habitacionesCreadas[0].GetComponent<vecinos>().vecino_izquierda = habitacionesCreadas[1].gameObject;
                habitacionesCreadas[1].GetComponent<vecinos>().vecino_derecha = habitacionesCreadas[0].gameObject;
                break;

            case 2:
                //DERECHA
                Instantiate(habitacion, transform);
                habitacionesCreadas.Add(transform.GetChild(1).GetChild(0).gameObject);
                habitacionesCreadas[1].transform.position = new Vector3(habitacionesCreadas[0].transform.position.x + 20f, habitacionesCreadas[0].transform.position.y, 0);
                habitacionesCreadas[1].transform.parent.name = "" + o;
                o++;
                habitacionesCreadas[0].GetComponent<vecinos>().vecino_derecha = habitacionesCreadas[1].gameObject;
                habitacionesCreadas[1].GetComponent<vecinos>().vecino_izquierda = habitacionesCreadas[0].gameObject;
                break;

            case 3:
                //ABAJO
                Instantiate(habitacion, transform);
                habitacionesCreadas.Add(transform.GetChild(1).GetChild(0).gameObject);
                habitacionesCreadas[1].transform.position = new Vector3(habitacionesCreadas[0].transform.position.x, habitacionesCreadas[0].transform.position.y - 10f, 0);
                habitacionesCreadas[1].transform.parent.name = "" + o;
                o++;
                habitacionesCreadas[0].GetComponent<vecinos>().vecino_abajo = habitacionesCreadas[1].gameObject;
                habitacionesCreadas[1].GetComponent<vecinos>().vecino_arriba = habitacionesCreadas[0].gameObject;
                break;


        }
        transform.GetComponent<cargarVecinos>().fijate_los_vecionos();

        //Las demas habitaciones

        for (int i = 2; i < cantidad_habitaciones; i++)
        {

            int x = Random.Range(0, i);

            numeroAleatorio = Random.Range(0, 4);

            if (habitacionesCreadas[x].GetComponent<vecinos>().cantidad_de_vecinos != 4)
            {
                switch (numeroAleatorio)
                {
                    case 0:
                        if (habitacionesCreadas[x].GetComponent<vecinos>().vecino_arriba == null)
                        {
                            //ARRIBA
                            Instantiate(habitacion, transform);
                            habitacionesCreadas.Add(transform.GetChild(i).GetChild(0).gameObject);
                            habitacionesCreadas[i].transform.position = new Vector3(habitacionesCreadas[x].transform.position.x, habitacionesCreadas[x].transform.position.y + 10f, 0);
                            habitacionesCreadas[i].transform.parent.name = "" + o;
                            habitacionesCreadas[x].GetComponent<vecinos>().vecino_arriba = habitacionesCreadas[i].gameObject;
                            habitacionesCreadas[i].GetComponent<vecinos>().vecino_abajo = habitacionesCreadas[x].gameObject;
                            o++;
                            transform.GetComponent<cargarVecinos>().fijate_los_vecionos();

                        }
                        else
                        {

                            i -= 1;
                        }
                        break;
                    case 1:
                        if (habitacionesCreadas[x].GetComponent<vecinos>().vecino_izquierda == null)
                        {
                            //IZQUIERDA
                            Instantiate(habitacion, transform);
                            habitacionesCreadas.Add(transform.GetChild(i).GetChild(0).gameObject);
                            habitacionesCreadas[i].transform.position = new Vector3(habitacionesCreadas[x].transform.position.x - 20f, habitacionesCreadas[x].transform.position.y, 0);
                            habitacionesCreadas[i].transform.parent.name = "" + o;
                            habitacionesCreadas[x].GetComponent<vecinos>().vecino_izquierda = habitacionesCreadas[i].gameObject;
                            habitacionesCreadas[i].GetComponent<vecinos>().vecino_derecha = habitacionesCreadas[x].gameObject;
                            o++;
                            transform.GetComponent<cargarVecinos>().fijate_los_vecionos();

                        }
                        else
                        {

                            i -= 1;
                        }

                        break;
                    case 2:
                        if (habitacionesCreadas[x].GetComponent<vecinos>().vecino_derecha == null)
                        {
                            //DERECHA
                            Instantiate(habitacion, transform);
                            habitacionesCreadas.Add(transform.GetChild(i).GetChild(0).gameObject);
                            habitacionesCreadas[i].transform.position = new Vector3(habitacionesCreadas[x].transform.position.x + 20f, habitacionesCreadas[x].transform.position.y, 0);
                            habitacionesCreadas[i].transform.parent.name = "" + o;
                            habitacionesCreadas[x].GetComponent<vecinos>().vecino_derecha = habitacionesCreadas[i].gameObject;
                            habitacionesCreadas[i].GetComponent<vecinos>().vecino_izquierda = habitacionesCreadas[x].gameObject;
                            o++;
                            transform.GetComponent<cargarVecinos>().fijate_los_vecionos();

                        }
                        else
                        {

                            i -= 1;
                        }

                        break;
                    case 3:
                        if (habitacionesCreadas[x].GetComponent<vecinos>().vecino_abajo == null)
                        {
                            //ABAJO
                            Instantiate(habitacion, transform);
                            habitacionesCreadas.Add(transform.GetChild(i).GetChild(0).gameObject);
                            habitacionesCreadas[i].transform.position = new Vector3(habitacionesCreadas[x].transform.position.x, habitacionesCreadas[x].transform.position.y - 10f, 0);
                            habitacionesCreadas[i].transform.parent.name = "" + o;
                            habitacionesCreadas[x].GetComponent<vecinos>().vecino_abajo = habitacionesCreadas[i].gameObject;
                            habitacionesCreadas[i].GetComponent<vecinos>().vecino_arriba = habitacionesCreadas[x].gameObject;
                            o++;
                            transform.GetComponent<cargarVecinos>().fijate_los_vecionos();


                        }
                        else
                        {

                            i -= 1;
                        }

                        break;
                }


            }
            else
            {
                i--;
            }



        }
    }

    void seleccionar_habitaciones_sin_salida()
    {
        int x = 1;
        for (int i = 1; i < cantidad_habitaciones; i++)
        {
            if (habitacionesCreadas[i].GetComponent<vecinos>().cantidad_de_vecinos == 1)
            {
                if (habitaciones_Especiales.Count == 5)
                {
                    x = cantidad_habitaciones;
                    i = cantidad_habitaciones;
                }
                else
                {
                    habitaciones_Especiales.Add(habitacionesCreadas[i]);
                }

            }
            x++;
        }

        if (x >= cantidad_habitaciones && habitaciones_Especiales.Count < 5)
        {
            for (int i = 1; i < cantidad_habitaciones; i++)
            {
                if (habitacionesCreadas[i].GetComponent<vecinos>().cantidad_de_vecinos == 2)
                {
                    if (habitaciones_Especiales.Count == 5)
                    {
                        i = cantidad_habitaciones;
                    }
                    else
                    {
                        habitaciones_Especiales.Add(habitacionesCreadas[i]);
                    }

                }

            }
        }

        

    }

    void seleccionarHabitacionesEspeciales()
    {
        habitacion_Jefe = habitaciones_Especiales[0].transform.parent.gameObject;
        habitacion_SubJefe = habitaciones_Especiales[1].transform.parent.gameObject;
        habitacion_mejora = habitaciones_Especiales[2].transform.parent.gameObject;
        habitacion_probabilidad = habitaciones_Especiales[3].transform.parent.gameObject;
        habitacion_violeta = habitaciones_Especiales[4].transform.parent.gameObject;
    }

    void reemplazar_habitaciones_especiales()
    {
        //Jefe
        Instantiate(habitacionRoja, habitacion_Jefe.transform.GetChild(0).position,Quaternion.Euler(0,0,0),habitacion_Jefe.transform);
        habitaciones_Especiales[0] = habitacion_Jefe.transform.GetChild(1).gameObject;
        habitaciones_Especiales[0].GetComponent<vecinos>().cantidad_de_vecinos = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().cantidad_de_vecinos -1;
        habitaciones_Especiales[0].GetComponent<vecinos>().habitaciones = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().habitaciones;
        habitaciones_Especiales[0].GetComponent<vecinos>().vecino_arriba = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().vecino_arriba;
        habitaciones_Especiales[0].GetComponent<vecinos>().vecino_izquierda = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().vecino_izquierda;
        habitaciones_Especiales[0].GetComponent<vecinos>().vecino_derecha = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().vecino_derecha;
        habitaciones_Especiales[0].GetComponent<vecinos>().vecino_abajo = habitacion_Jefe.transform.GetChild(0).GetComponent<vecinos>().vecino_abajo;

        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            if (habitacionesCreadas[i].gameObject == habitacion_Jefe.transform.GetChild(0).gameObject)
            {
                habitacionesCreadas.Remove(habitacion_Jefe.transform.GetChild(0).gameObject);
                habitacionesCreadas.Insert(i, habitaciones_Especiales[0]);
                
            }
        }
        Destroy(habitacion_Jefe.transform.GetChild(0).gameObject);
        habitaciones_Especiales[0].GetComponent<vecinos>().buscar_vecinos();

        

        //SubJefe
        Instantiate(habitacionVerde, habitacion_SubJefe.transform.GetChild(0).position, Quaternion.Euler(0, 0, 0), habitacion_SubJefe.transform);
        habitaciones_Especiales[1] = habitacion_SubJefe.transform.GetChild(1).gameObject;
        habitaciones_Especiales[1].GetComponent<vecinos>().cantidad_de_vecinos = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().cantidad_de_vecinos -1;
        habitaciones_Especiales[1].GetComponent<vecinos>().habitaciones = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().habitaciones;
        habitaciones_Especiales[1].GetComponent<vecinos>().vecino_arriba = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().vecino_arriba;
        habitaciones_Especiales[1].GetComponent<vecinos>().vecino_izquierda = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().vecino_izquierda;
        habitaciones_Especiales[1].GetComponent<vecinos>().vecino_derecha = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().vecino_derecha;
        habitaciones_Especiales[1].GetComponent<vecinos>().vecino_abajo = habitacion_SubJefe.transform.GetChild(0).GetComponent<vecinos>().vecino_abajo;

        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            if (habitacionesCreadas[i].gameObject == habitacion_SubJefe.transform.GetChild(0).gameObject)
            {
                habitacionesCreadas.Remove(habitacion_SubJefe.transform.GetChild(0).gameObject);
                habitacionesCreadas.Insert(i, habitaciones_Especiales[1]);

            }
        }
        Destroy(habitacion_SubJefe.transform.GetChild(0).gameObject);

        

        //Mejora
        Instantiate(habitacionAmarilla, habitacion_mejora.transform.GetChild(0).position, Quaternion.Euler(0, 0, 0), habitacion_mejora.transform);
        habitaciones_Especiales[2] = habitacion_mejora.transform.GetChild(1).gameObject;
        habitaciones_Especiales[2].GetComponent<vecinos>().cantidad_de_vecinos = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().cantidad_de_vecinos -1;
        habitaciones_Especiales[2].GetComponent<vecinos>().habitaciones = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().habitaciones;
        habitaciones_Especiales[2].GetComponent<vecinos>().vecino_arriba = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().vecino_arriba;
        habitaciones_Especiales[2].GetComponent<vecinos>().vecino_izquierda = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().vecino_izquierda;
        habitaciones_Especiales[2].GetComponent<vecinos>().vecino_derecha = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().vecino_derecha;
        habitaciones_Especiales[2].GetComponent<vecinos>().vecino_abajo = habitacion_mejora.transform.GetChild(0).GetComponent<vecinos>().vecino_abajo;
        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            if (habitacionesCreadas[i].gameObject == habitacion_mejora.transform.GetChild(0).gameObject)
            {
                habitacionesCreadas.Remove(habitacion_mejora.transform.GetChild(0).gameObject);
                habitacionesCreadas.Insert(i, habitaciones_Especiales[2]);

            }
        }
        Destroy(habitacion_mejora.transform.GetChild(0).gameObject);

        

        //Probabilidad
        Instantiate(habitacionAzul, habitacion_probabilidad.transform.GetChild(0).position, Quaternion.Euler(0, 0, 0), habitacion_probabilidad.transform);
        habitaciones_Especiales[3] = habitacion_probabilidad.transform.GetChild(1).gameObject;
        habitaciones_Especiales[3].GetComponent<vecinos>().cantidad_de_vecinos = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().cantidad_de_vecinos - 1;
        habitaciones_Especiales[3].GetComponent<vecinos>().habitaciones = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().habitaciones;
        habitaciones_Especiales[3].GetComponent<vecinos>().vecino_arriba = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().vecino_arriba;
        habitaciones_Especiales[3].GetComponent<vecinos>().vecino_izquierda = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().vecino_izquierda;
        habitaciones_Especiales[3].GetComponent<vecinos>().vecino_derecha = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().vecino_derecha;
        habitaciones_Especiales[3].GetComponent<vecinos>().vecino_abajo = habitacion_probabilidad.transform.GetChild(0).GetComponent<vecinos>().vecino_abajo;
        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            if (habitacionesCreadas[i].gameObject == habitacion_probabilidad.transform.GetChild(0).gameObject)
            {
                habitacionesCreadas.Remove(habitacion_probabilidad.transform.GetChild(0).gameObject);
                habitacionesCreadas.Insert(i, habitaciones_Especiales[3]);

            }
        }
        Destroy(habitacion_probabilidad.transform.GetChild(0).gameObject);

        

        //Violeta
        Instantiate(habitacionVioleta, habitacion_violeta.transform.GetChild(0).position, Quaternion.Euler(0, 0, 0), habitacion_violeta.transform);
        habitaciones_Especiales[4] = habitacion_violeta.transform.GetChild(1).gameObject;
        habitaciones_Especiales[4].GetComponent<vecinos>().cantidad_de_vecinos = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().cantidad_de_vecinos - 1;
        habitaciones_Especiales[4].GetComponent<vecinos>().habitaciones = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().habitaciones;
        habitaciones_Especiales[4].GetComponent<vecinos>().vecino_arriba = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().vecino_arriba;
        habitaciones_Especiales[4].GetComponent<vecinos>().vecino_izquierda = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().vecino_izquierda;
        habitaciones_Especiales[4].GetComponent<vecinos>().vecino_derecha = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().vecino_derecha;
        habitaciones_Especiales[4].GetComponent<vecinos>().vecino_abajo = habitacion_violeta.transform.GetChild(0).GetComponent<vecinos>().vecino_abajo;
        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            if (habitacionesCreadas[i].gameObject == habitacion_violeta.transform.GetChild(0).gameObject)
            {
                habitacionesCreadas.Remove(habitacion_violeta.transform.GetChild(0).gameObject);
                habitacionesCreadas.Insert(i, habitaciones_Especiales[4]);

            }
        }
        Destroy(habitacion_violeta.transform.GetChild(0).gameObject);


        for (int i = 0; i < habitacionesCreadas.Count; i++)
        {
            habitacionesCreadas[i].GetComponent<vecinos>().buscar_vecinos();
        }

        

    }

    void borrarPuertas()
    {
        for (int i = 0; i < cantidad_habitaciones; i++)
        {
            for (int x = 0; x < 4; x++)
            {
                listapuertas.Add(habitacionesCreadas[i].transform.GetChild(0).transform.GetChild(1).transform.GetChild(x).gameObject);

            }

        }

        for (int e = 0; e < listapuertas.Count; e++)
        {
            if (listapuertas[e].GetComponent<puertaLibre>().libre)
            {
                listapuertas[e].transform.GetChild(0).gameObject.SetActive(false);
                listapuertas[e].transform.GetChild(1).gameObject.SetActive(false);
                listapuertas[e].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                listapuertas[e].GetComponent<puertaLibre>().analizarHabitaciones();
            }
        }


    }
    
    void generarObstaculos()
    {
        for (int i = 1; i < habitacionesCreadas.Count; i++)
        {
            bool no_es_especial = true;
            
            foreach (GameObject especial  in habitaciones_Especiales)
            {
                if (habitacionesCreadas[i] == especial)
                {
                    no_es_especial = false;
                }
            }

            if(no_es_especial == true)
            {
                int nro = Random.Range(0, obsta.Count);
                Instantiate(obsta[nro],habitacionesCreadas[i].transform.GetChild(1).transform);
                if (!habitacionesCreadas[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<colliderPiso>().mejora && habitacionesCreadas[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<colliderPiso>().spawns == null)
                {
                    habitacionesCreadas[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<colliderPiso>().spawns = habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
                }
                



            }
        }
    }

    void generar_enemigos()
    {
        
        for (int i = 1; i < habitacionesCreadas.Count; i++)
        {
            es_especial = false;
            
            for (int x = 0; x < habitaciones_Especiales.Count; x++)
            {
                if (habitacionesCreadas[i].gameObject == habitaciones_Especiales[x])
                {
                    es_especial = true;
                    
                }
            }
            if(es_especial == false)
            {
                switch (nivel)
                {
                    case 1:
                        int cantidad_enemigos = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);
                        for (int e = 0; e < cantidad_enemigos; e++)
                        {
                            no_parar_bucle = true;
                            numero = Random.Range(0, enemigos_nivel1.Count);
                        
                            posicion = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);     
                            while(no_parar_bucle == true)
                            {
                                if(habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion).childCount != 0)
                                {
                                    posicion = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);
                                }
                                else
                                {
                                    no_parar_bucle = false;
                                }
                            }
                            Instantiate(enemigos_nivel1[numero], habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion).position, Quaternion.Euler(0,0,0), habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion));
                        }
                            
                    break;

                    case 2:
                        int cantidad_enemigos2 = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);
                        for (int e = 0; e < cantidad_enemigos2; e++)
                        {
                            no_parar_bucle = true;
                            numero = Random.Range(0, enemigos_nivel2.Count);

                            posicion = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);
                            while (no_parar_bucle == true)
                            {
                                if (habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion).childCount != 0)
                                {
                                    posicion = Random.Range(0, habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).childCount);
                                }
                                else
                                {
                                    no_parar_bucle = false;
                                }
                            }
                            Instantiate(enemigos_nivel2[numero], habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion).position, Quaternion.Euler(0, 0, 0), habitacionesCreadas[i].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(posicion));
                        }

                        break;

                }
            }
            
        }
    }

    void sacarPantalladeCarga()
    {
        GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
    }


}
