using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton_Sound : MonoBehaviour
{
    public AudioSource source { get { return GetComponent<AudioSource>(); } }
    public Button Btn { get { return GetComponent<Button>(); } }

    public AudioClip BotonSound;
    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        Btn.onClick.AddListener(PlaySound);
    }

    // Update is called once per frame
    void PlaySound()
    {
        source.PlayOneShot (BotonSound);
    }
}
