using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronMove : MonoBehaviour
{
    Transform refencia;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        refencia = GameObject.FindGameObjectWithTag("seguidor").transform;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().pc)
        {
            ani.SetFloat("horizontal", GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().apuntado.Horizontal);
            ani.SetFloat("vertical", GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().apuntado.Vertical);
        }
        else
        {
            ani.SetFloat("horizontal", GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().keyboardHorizontal);
            ani.SetFloat("vertical", GameObject.FindGameObjectWithTag("Player").GetComponent<playerMoves>().keyboardVertical);
        }
        transform.Translate((refencia.position - transform.position) * Time.deltaTime,Space.World);
        
    }
}
