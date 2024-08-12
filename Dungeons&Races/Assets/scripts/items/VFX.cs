using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] AudioClip sonido;

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
