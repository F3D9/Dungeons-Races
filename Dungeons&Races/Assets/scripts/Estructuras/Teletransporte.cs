using System.Collections;
using System.Collections.Generic;
using System.Threading;


using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    [SerializeField] int escena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(escena == 0)
            {
                
                GameObject.FindGameObjectWithTag("Admin").GetComponent<menuButtons>().victoria.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Admin").GetComponent<DatosMuerte>().ganaste = true;
                GameObject.FindGameObjectWithTag("Generador").gameObject.SetActive(false);
                
                Time.timeScale = 0;
            }
            else
            {
                
                GameObject.FindGameObjectWithTag("Carga").transform.GetChild(0).gameObject.SetActive(true);
                //GameObject.FindGameObjectWithTag("Generador").gameObject.SetActive(false);
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex));
                //SceneManager.LoadScene(0);
                Invoke("cargarNuevaEscena", 2);
                
                
            }
            
        }
    }

    void cargarNuevaEscena()
    {
        SceneManager.LoadSceneAsync(escena,LoadSceneMode.Single);
    }

}
