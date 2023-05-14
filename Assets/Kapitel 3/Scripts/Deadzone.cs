using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerControllerWithJoypadSupport>().ResetPosition();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().loseALife();
        }
    }
}
