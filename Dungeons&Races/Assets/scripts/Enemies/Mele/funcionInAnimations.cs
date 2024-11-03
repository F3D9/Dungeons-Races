using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcionInAnimations : MonoBehaviour
{

    void InvisibleTrue()
    {
        GetComponent<Animator>().SetBool("invisible", true);
    }

    void InvisibleFalse()
    {
        GetComponent<Animator>().SetBool("invisible", false);
    }

    void inTransition()
    {
        if (GetComponentInParent<GreenAlien>().transition)
        {
            GetComponentInParent<GreenAlien>().transition = false;
        }
        else
        {
            GetComponentInParent<GreenAlien>().transition = true;
        }

    }
}
