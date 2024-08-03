using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarPersonaje : MonoBehaviour
{
    enum tipo_de_personaje
    {
        ogro,
        robot_blanco,
        humano
    }

    [SerializeField] tipo_de_personaje personaje;
    public int comprar = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("OgroComprado", 0);
        //PlayerPrefs.SetInt("RobotComprado", 0);
        //PlayerPrefs.SetInt("HumanoComprado", 0);

        switch (personaje)
        {
            case tipo_de_personaje.ogro:
                comprar = PlayerPrefs.GetInt("OgroComprado");
                break;
            
            case tipo_de_personaje.robot_blanco:
                comprar = PlayerPrefs.GetInt("RobotComprado");
                break;
            case tipo_de_personaje.humano:
                comprar = PlayerPrefs.GetInt("HumanoComprado");
                break;
        }
        
        if (comprar == 0)
        {
            gameObject.SetActive(true);
        }
        if (comprar == 1)
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (comprar == 0)
        {
            switch (personaje)
            {
                case tipo_de_personaje.ogro:
                    PlayerPrefs.SetInt("OgroComprado",0);
                    break;

                case tipo_de_personaje.robot_blanco:
                    PlayerPrefs.SetInt("RobotComprado",0);
                    break;
                case tipo_de_personaje.humano:
                    PlayerPrefs.SetInt("HumanoComprado", 0);
                    break;
            }
            gameObject.SetActive(true);
        }
        if (comprar == 1)
        {
            switch (personaje)
            {
                case tipo_de_personaje.ogro:
                    PlayerPrefs.SetInt("OgroComprado", 1);
                    break;

                case tipo_de_personaje.robot_blanco:
                    PlayerPrefs.SetInt("RobotComprado", 1);
                    break;
                case tipo_de_personaje.humano:
                    PlayerPrefs.SetInt("HumanoComprado", 1);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
