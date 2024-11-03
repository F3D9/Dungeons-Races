using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaJefe : MonoBehaviour
{
    public GameObject jefe1, jefe2;
   
    [SerializeField] GameObject tp;
    [SerializeField] AudioClip spawn;

    [Header("Reward")]
    [SerializeField] GameObject altar;
    [SerializeField] GameObject particles;
    [SerializeField] AudioClip horn;
    bool unaVez = false;
    

    // Update is called once per frame
    void Update()
    {
        if (!unaVez)
        {
            if(jefe1 == null && jefe2 == null)
            {
                altar.SetActive(true);
                Instantiate(particles,transform.position,Quaternion.Euler(0, 0, 0));
                SonidoControler.Instance.ejecutarSonido(horn);

                if(tp!= null)
                {
                    tp.SetActive(true);
                }

                SonidoControler.Instance.ejecutarSonido(spawn);
                unaVez = true;
            }
            else
            {
                altar.SetActive(false);
                if (tp != null)
                {
                    tp.SetActive(false);
                }
            }
        }
        
    }
}
