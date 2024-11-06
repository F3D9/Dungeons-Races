using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronDisparo : MonoBehaviour
{
    [SerializeField] GameObject bala;
    float timer, condicion;
    Transform puntaArma;
    
    //Mobile
    Joystick apuntado;
    float anguloRadianes;
    float anguloGrados;

    //PC
    float horShoot;
    float verShoot;

    // Start is called before the first frame update
    void Start()
    {
        apuntado = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().apuntado;
        puntaArma = transform.GetChild(0);
        bala.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        condicion = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().pc)
        {
            anguloRadianes = Mathf.Atan2(apuntado.Vertical, apuntado.Horizontal);

            anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            puntaArma.rotation = Quaternion.Euler(0, 0, anguloGrados);

            timer += Time.deltaTime;

            if (apuntado.Horizontal < 0 || apuntado.Horizontal > 0 || apuntado.Vertical < 0 || apuntado.Vertical > 0)
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
            horShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().keyboardHorizontal;
            verShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().keyboardVertical;

            if (verShoot != 0 && horShoot != 0)
            {
                anguloRadianes = Mathf.Atan2(verShoot, horShoot);

                anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
                puntaArma.rotation = Quaternion.Euler(0, 0, anguloGrados);
            }
            else
            {
                puntaArma.rotation = Quaternion.Euler(0, 0, 0);
            }

            timer += Time.deltaTime;

            if (horShoot != 0.01f || verShoot != 0.01f)
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
