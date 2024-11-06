using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatosMuerte : MonoBehaviour
{
    [Header("Textos Muerte")]
    [SerializeField] TMP_Text tiempo;
    [SerializeField] TMP_Text puntaje;
    [SerializeField] TMP_Text ganancia;

    [Header("Textos Victoria")]
    [SerializeField] TMP_Text tiempoVictoria;
    [SerializeField] TMP_Text puntajeVictoria;
    [SerializeField] TMP_Text gananciaVictoria;

    [Header("Victoria")]
    public bool ganaste = false;

    float timer;
    int score;
    int ganancia_monedaAzul;

    bool unaVez;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        unaVez = false;
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutos = Mathf.FloorToInt(timer / 60);
        int segundos = Mathf.FloorToInt(timer % 60);

        tiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        tiempoVictoria.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        


        puntaje.text = PlayerPrefs.GetInt("Score").ToString();
        puntajeVictoria.text = PlayerPrefs.GetInt("Score").ToString();

        if (!ganaste)
        {
            switch (SceneManager.GetActiveScene().buildIndex) 
            {
                case 1:
                    ganancia_monedaAzul = 5;
                    break;
                case 2:
                    ganancia_monedaAzul = 10;
                    break;

            }
        }
        else
        {
            ganancia_monedaAzul = 25;
        }
        
        ganancia.text = "+ " + ganancia_monedaAzul.ToString();
        gananciaVictoria.text = "+ " + ganancia_monedaAzul.ToString();

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<playerAtributtes>().vidaTotal <= 0 || ganaste)
        {
            if (!unaVez)
            {
                PlayerPrefs.SetInt("MonedaAzul", PlayerPrefs.GetInt("MonedaAzul") + ganancia_monedaAzul);
                unaVez=true;
            }
            
        }
        

    }


}
