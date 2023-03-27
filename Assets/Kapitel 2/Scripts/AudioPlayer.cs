using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip coin;
    public AudioClip goal;

    public void playCoinPickupSFX()
    {
        GetComponent<AudioSource>().clip = coin;
        GetComponent<AudioSource>().Play();
    }

    public void playGoalSFX()
    {
        GetComponent<AudioSource>().clip = goal;
        GetComponent<AudioSource>().Play();
    }
}
