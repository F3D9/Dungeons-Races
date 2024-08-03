using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarGameObjects : MonoBehaviour
{
    public static GuardarGameObjects Instance;
  
    // Start is called before the first frame update
    void Awake()
    {
        if(GuardarGameObjects.Instance == null)
        {
            GuardarGameObjects.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    public void guardarObjecto()
    {
        if (GuardarGameObjects.Instance == null)
        {
            GuardarGameObjects.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
