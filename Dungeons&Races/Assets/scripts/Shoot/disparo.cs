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
    public GameObject Hueso;

    // Start is called before the first frame update
    void Start()
    {
        bala = Hueso;
        puntaArma = transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(mira.Horizontal < 0 || mira.Horizontal > 0  || mira.Vertical < 0 || mira.Vertical > 0)     
        {
            
            if (timer >= condicion)
            {
                Instantiate(bala, puntaArma.position, puntaArma.rotation);
                timer = 0;
            }
            
        }
    }
}
