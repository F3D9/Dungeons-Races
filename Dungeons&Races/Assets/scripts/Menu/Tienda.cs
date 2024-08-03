using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField] TMP_Text monedatxt;
    [SerializeField] int monedaNumero;

    // Start is called before the first frame update
    void Start()
    {
        monedaNumero = PlayerPrefs.GetInt("MonedaAzul");
        //PlayerPrefs.SetInt("MonedaAzul", 0);

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("MonedaAzul",monedaNumero);
        if (monedaNumero > 99999)
        {
            monedaNumero = 99999;

        }
        monedatxt.text = monedaNumero.ToString();
    }

    public void BotonComprar(GameObject boton)
    {
        if(monedaNumero >= 100)
        {
            monedaNumero -= 100;
            boton.GetComponent<ComprarPersonaje>().comprar = 1;
        }
    }


}
