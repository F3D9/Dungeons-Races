using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverseConLasPuertas : MonoBehaviour
{
    public int tipo_de_puerta;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.parent.childCount; i++)
        {
            if(transform.parent.parent.GetChild(i).gameObject == transform.parent.gameObject)
            {
                tipo_de_puerta = i+1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (tipo_de_puerta)
            {
                case 1:
                    collision.transform.position = new Vector3(GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.x, GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.y + 1, collision.transform.position.z);
                    
                    break;
                case 2:
                    collision.transform.position = new Vector3(GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.x - 1, GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.y, collision.transform.position.z);
                    
                    break;
                case 3:
                    collision.transform.position = new Vector3(GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.x + 1, GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.y, collision.transform.position.z);
                    
                    break;
                case 4:
                    collision.transform.position = new Vector3(GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.x, GetComponentInParent<puertaLibre>().puerta_conectada.transform.position.y - 1, collision.transform.position.z);
                    
                    break;
            }
            


        }
    }

}
