using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidoControler : MonoBehaviour
{
    public static SonidoControler Instance;
    public AudioMixer mixer;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        audio = GetComponent<AudioSource>();
        mixer.SetFloat("VolMusic", PlayerPrefs.GetFloat("Music"));
        mixer.SetFloat("VolFX", PlayerPrefs.GetFloat("Effects"));
    }

    public void ejecutarSonido(AudioClip sonido)
    {
        audio.PlayOneShot(sonido);
    }
}
