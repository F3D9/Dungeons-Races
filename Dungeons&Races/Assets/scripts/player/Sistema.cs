using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sistema : MonoBehaviour
{
    [Header("Tipo de raza")]
    [SerializeField] int raza;

    [Header("Valores")]
    [Header("Velocidad")]
    public float velocidad = 5;
    public float velocidadNormal = 5;
    public float velocidad_en_telaraña;

    [Header("Slime")]
    public GameObject slime;
    public bool crearSlime = false;
    float timer;

    [Header("Oro")]
    public float oro;
    public TMP_Text numero_en_pantalla;

    [Header("Apariencia")]
    public int apariencia = 0;

    // Start is called before the first frame update
    void Start()
    {

        velocidad_en_telaraña = velocidadNormal / 2;
        velocidadNormal = velocidad;

        PlayerPrefs.SetInt("raza", raza);

    }

    // Update is called once per frame
    void Update()
    {
        numero_en_pantalla.text = oro.ToString();

        if (crearSlime && slime != null)
        {
            timer += Time.deltaTime;
            if(timer > 0.2f)
            {
                Instantiate(slime,new Vector3(transform.position.x,transform.position.y - 0.49f,transform.position.z),Quaternion.Euler(0, 0, 0));
                timer = 0;
            }
            
        }

    }

    

}
