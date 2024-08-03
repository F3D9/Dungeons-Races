using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    [SerializeField] int escena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(escena == 0)
            {
                GameObject.FindGameObjectWithTag("Admin").GetComponent<menuButtons>().victoria.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Admin").GetComponent<DatosMuerte>().ganaste = true;
            }
            else
            {
            SceneManager.LoadScene(escena);
            }
            
        }
    }
}
