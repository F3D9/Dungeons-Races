
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerAtributtes : MonoBehaviour
{
    [Header("Canva Vida")]
    public Canvas canva;
    public Canvas menu_de_muerte;
    public List<Image> vida = new List<Image>();
    public AudioClip recibirdaño;
    float timer;
    bool inmunidad = false;
    float tiempo_inmune;

    public float vidaTotal = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        menu_de_muerte.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(vida.Count > 0)
        {
            timer += Time.deltaTime;

            for (int i = 0; i < vida.Count; i++)
            {
                if(vida[i].fillAmount <= 0)
                {
                    
                    Destroy(vida[i]);
                    Destroy(GameObject.FindGameObjectWithTag("Vida").transform.GetChild(i).gameObject);
                    vida.RemoveAt(i);

                }
                else
                {
                    vida[i].fillAmount = vida[i].fillAmount / 1;
                }
            
            }
            tiempo_inmune = 0;
        }
        else
        {
           
            Time.timeScale = 0f;
            menu_de_muerte.gameObject.SetActive(true);
            
        }
        
        
     
        
        
    }

    public void tomarDaño(float damage)
    {
        if(timer >= 1f)
        {
            float daño = damage;
            int x = 1;
            for (int i = 0; i < damage; i++)
            {
                if (daño > 0)
                {
                    vida[vida.Count - x].fillAmount -= daño;
                    daño --;
                    x++;
                }
                
            }
            
            vidaTotal -= damage;
            timer = 0f;
            inmunidad = true;
            GetComponentInChildren<Animator>().SetBool("damage", true);
            SonidoControler.Instance.ejecutarSonido(recibirdaño);
        }
        
    }

}
