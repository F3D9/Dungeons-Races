using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAmarilloItem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    int numero;

    // Start is called before the first frame update
    void Start()
    {
        numero = Random.Range(0, items.Count);
        Instantiate(items[numero], transform.position, Quaternion.Euler(0, 0, 0), transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
