using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piedras_que_se_rompen : MonoBehaviour
{
    [Header("Cosas")]
    public int modo = 1;
    public Sprite modo1,modo2,modo3;
    SpriteRenderer Sprite;
    Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.enabled = false;
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            switch (modo)
            {
            case 1:
                Sprite.sprite = modo1;
                break;
            case 2:
                Sprite.sprite = modo2;
                break;
            case 3:
                Sprite.sprite = modo3;
                break;
            case 4:
                ani.enabled = true;
                    
                break;
            }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            modo += 1;
            
        }
    }

    void des()
    {
        GameObject.FindGameObjectWithTag("Admin").transform.GetComponent<soltarObjetos>().soltarObjeto(transform.position);
        Destroy(gameObject);
    }



    

}
