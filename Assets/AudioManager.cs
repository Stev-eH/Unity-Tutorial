using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coinPickup;
    public AudioClip goalAppear;

    private AudioSource source;

    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    public void coinSFX()
    {
        source.clip = coinPickup;
        source.Play();
    }

    public void goalSFX()
    {
        source.clip = goalAppear;
        source.Play();
    }
}
