using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorReferencia : MonoBehaviour
{
    double x, y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Math.Pow(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().horizontal,2);
        y = Math.Pow(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().vertical,2);
        
        if (x >y)
        {
            transform.localPosition = new Vector3(0, -0.8f, 0);
        }
        if (x<y)
        {
            transform.localPosition = new Vector3(0.8f, 0, 0);
        }
    }
}
