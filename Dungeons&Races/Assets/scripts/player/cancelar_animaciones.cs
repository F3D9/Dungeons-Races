using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelar_animaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cancelarDamage()
    {
        GetComponent<Animator>().SetBool("damage", false);
    }

}
