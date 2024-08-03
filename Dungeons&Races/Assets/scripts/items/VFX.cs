using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] AudioClip sonido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destruir()
    {
        Destroy(gameObject);
    }

    void reproducirSonido()
    {
        SonidoControler.Instance.ejecutarSonido(sonido);
    }

    void cortarAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }

    void girarSprite()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
