using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    
    public Joystick mira;
    Transform puntaArma;
    float timer;
    public float condicion;

    [Header("Municion")]
    public GameObject bala;
    public GameObject StartAmmo;

    // Start is called before the first frame update
    void Start()
    {
        bala = StartAmmo;
        puntaArma = transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!GetComponent<playerMoves>().pc)
        {
            if(mira.Horizontal != 0  || mira.Vertical != 0)     
            {
            
                if (timer >= condicion)
                {
                    Instantiate(bala, puntaArma.position, puntaArma.rotation);
                    timer = 0;
                }
            
            }
        }
        else
        {
            if (GetComponent<playerMoves>().keyboardHorizontal != 0.01f || GetComponent<playerMoves>().keyboardVertical != 0.01f)
            {

                if (timer >= condicion)
                {
                    Instantiate(bala, puntaArma.position, puntaArma.rotation);
                    timer = 0;
                }

            }
        }
        
    }
}
