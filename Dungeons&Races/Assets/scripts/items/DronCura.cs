using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronCura : MonoBehaviour
{
    [SerializeField] GameObject corazon1;
    [SerializeField] GameObject corazon2;
    [SerializeField] float tiempo;
    float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tiempo)
        {
            if(Random.value <= 0.9f)
            {
                Instantiate(corazon1, transform.position, Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(corazon2, transform.position, Quaternion.Euler(0, 0, 0));
            }
            timer = 0;
        }

    }
}
