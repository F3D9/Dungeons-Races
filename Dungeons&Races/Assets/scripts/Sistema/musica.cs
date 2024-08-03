using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica : MonoBehaviour
{
    [SerializeField] List<AudioClip> listaMusica = new List<AudioClip>();

    float timer;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            timer += Time.deltaTime;

            if(timer >= 10f)
            {
                int nro = Random.Range(0, listaMusica.Count);
                audio.PlayOneShot(listaMusica[nro]);
                timer = 0;
            }
        }
        
    }
}
