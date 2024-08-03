using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soltarObjetos : MonoBehaviour
{
    [Header("Lista")]
    public List<GameObject> lista = new List<GameObject>();
    public float probabilidad = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void soltarObjeto(Vector3 posicion)
    {
        if(Random.value < probabilidad)
        {
            int nro = Random.Range(0, lista.Count);
            Instantiate(lista[nro], posicion,Quaternion.Euler(0,0,0));
        }

        
        
    }
}
