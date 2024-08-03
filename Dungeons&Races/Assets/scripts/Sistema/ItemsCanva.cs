using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemsCanva : MonoBehaviour
{
    public TMP_Text nombreItem;
    public TMP_Text infoItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cargarCanvaItem(string nombre,string info)
    {
        transform.position = new Vector3(-680, 106, 0);
        nombreItem.text = nombre;
        infoItem.text = info;
        LeanTween.moveX(transform.GetChild(0).GetComponent<RectTransform>(), 0, 0.8f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveX(transform.GetChild(0).GetComponent<RectTransform>(), -680, 0.3f).setEase(LeanTweenType.easeInBack).setDelay(2);

    }


}
