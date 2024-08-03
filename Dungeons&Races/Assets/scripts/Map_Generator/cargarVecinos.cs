using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarVecinos : MonoBehaviour
{
    public int total;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fijate_los_vecionos()
    {
        total++;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<vecinos>().habitaciones = total;
            transform.GetChild(i).GetChild(0).GetComponent<vecinos>().buscar_vecinos();
                
                
        }
    
    }

}
