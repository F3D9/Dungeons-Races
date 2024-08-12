using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarAdmin : MonoBehaviour
{
    public static GuardarAdmin Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (GuardarAdmin.Instance == null)
        {
            GuardarAdmin.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    
}
