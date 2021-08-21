using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    static public AudioMan instance;
    public List<AudioClip> sounds;
    AudioSource audSrc;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void OnEnable()
    {
        audSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(int i, float vol = 1)
    {
        audSrc.pitch = Random.Range(.99f, 1.1f);
        audSrc.PlayOneShot(sounds[i], vol);
    }
}
