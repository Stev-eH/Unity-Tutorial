using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Audioclips a directy assigned in the inspector
    public AudioClip coin;
    public AudioClip goal;

    // these functions will be called by other objects
    public void playCoinPickupSFX()
    {
        // switch the active audioclip
        GetComponent<AudioSource>().clip = coin;
        // play it
        GetComponent<AudioSource>().Play();
    }

    public void playGoalSFX()
    {
        GetComponent<AudioSource>().clip = goal;
        GetComponent<AudioSource>().Play();
    }
}
