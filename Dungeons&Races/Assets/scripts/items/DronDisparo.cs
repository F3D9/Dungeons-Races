using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronDisparo : MonoBehaviour
{
    [SerializeField] GameObject bala;
    Joystick apuntado;
    float anguloRadianes;
    float anguloGrados;
    float timer, condicion;
    Transform puntaArma;
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
}
