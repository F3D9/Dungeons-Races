
using MilkShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerAtributtes : MonoBehaviour
{
    [Header("Canva Vida")]
    public Canvas canva;
    public Canvas menu_de_muerte,controles;
    public List<Image> vida = new List<Image>();
    public AudioClip recibirdaño;
    float timer;
    bool inmunidad = false;
    float tiempo_inmune;
    bool cargarAnuncio = false;

    public float vidaTotal = 3f;


    [Header("Shake Camera")]
    [SerializeField] ShakePreset shakePresets;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        controles.gameObject.SetActive(true);
        menu_de_muerte.gameObject.SetActive(false);
        cargarAnuncio = true;
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
            if (cargarAnuncio)
            {
                //ControladorAnuncios.Instance.ShowInterstitialAd();
                cargarAnuncio = false;
            }
            controles.gameObject.SetActive(false);

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
            GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Shaker>().Shake(shakePresets);
            //Handheld.Vibrate();
        }
        
    }

}
