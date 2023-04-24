using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform tf;
    private bool invertMovement = true;
    private float invertTime = 2f;
    private float invertTimer;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        invertTimer = invertTime / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (invertMovement)
        {
            tf.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            tf.Translate(-Vector3.right * Time.deltaTime);
        }
        timer();
    }

    void timer()
    {
        invertTimer -= Time.deltaTime;
        if (invertTimer < 0)
        {
            invertMovement = !invertMovement;
            invertTimer = invertTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            //collision.gameObject.GetComponent<PlayerController>().ResetPosition();
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().loseALife();
        }
    }
}
