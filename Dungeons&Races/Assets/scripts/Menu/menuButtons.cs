using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public Canvas atributos, joysticks, muerte, pausa, minimapa,victoria;
    public bool partida;
    [SerializeField] GameObject control_Disparo,control_Movimiento;

    bool mapa = false;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(false);
        }
        victoria.gameObject.SetActive(false);
    }

    public void Play()
    {
        muerte.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        atributos.gameObject.SetActive(false);
        joysticks.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        minimapa.gameObject.SetActive(false);

        GameObject[] lista = GameObject.FindGameObjectsWithTag("Mapa");
        for (int i = 0; i < lista.Length; i++)
        {
            lista[i].SetActive(false);
        }
    }

    public void Restart()
    {
        muerte.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        atributos.gameObject.SetActive(false);
        joysticks.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(1);
        
    }

    public void Menu()
    {
        
        GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(0);
        
    }

    
    public void Pausa()
    {
        if(Time.timeScale == 1)
        {
            atributos.gameObject.SetActive(false);
            joysticks.gameObject.SetActive(false);
            muerte.gameObject.SetActive(false);
            pausa.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            atributos.gameObject.SetActive(true);
            joysticks.gameObject.SetActive(true);
            muerte.gameObject.SetActive(false);
            pausa.gameObject.SetActive(false);
            

            
            Time.timeScale = 1;
        }
    }


    public void MiniMapa()
    {
        if (!mapa)
        {   
            minimapa.gameObject.SetActive(true);
            control_Disparo.SetActive(false);
            control_Movimiento.SetActive(false);
            mapa = true;
        }
        else
        {
            control_Disparo.SetActive(true);
            control_Movimiento.SetActive(true);
            minimapa.gameObject.SetActive(false);
            mapa = false;
            
        }
    }

}
