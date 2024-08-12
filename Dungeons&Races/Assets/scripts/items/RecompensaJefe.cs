using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaJefe : MonoBehaviour
{
    public GameObject jefe1, jefe2;
    [SerializeField] GameObject altar;
    [SerializeField] GameObject tp;
    [SerializeField] AudioClip spawn;
    bool unaVez = false;
    

    // Update is called once per frame
    void Update()
    {
        if (!unaVez)
        {
            if(jefe1 == null && jefe2 == null)
            {
                altar.SetActive(true);
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
