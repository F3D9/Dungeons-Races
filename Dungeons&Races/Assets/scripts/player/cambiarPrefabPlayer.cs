using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarPrefabPlayer : MonoBehaviour
{
    [SerializeField] GameObject esqueleto;
    [SerializeField] GameObject ogro;
    [SerializeField] GameObject robot;
    [SerializeField] GameObject humano;

    // Update is called once per frame
    void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            switch (PlayerPrefs.GetInt("raza"))
            {
                case 0:
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Instantiate(esqueleto,new Vector3(0,0,0),Quaternion.Euler(0,0,0));
                    break;
                case 1:
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Instantiate(ogro, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
                    break;
                case 2:
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Instantiate(robot, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
                    break;
                case 3:
                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Instantiate(humano, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
                    break;
            }
        }
    }
}
