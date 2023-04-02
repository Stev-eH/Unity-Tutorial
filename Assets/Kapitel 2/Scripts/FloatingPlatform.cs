using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    Transform platform;

    public float moveDistance = 1f;

    bool invertMovement;
    float timer;
    const float setTime = 5f;

    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Transform>();
        invertMovement = false;
        timer = setTime;

        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        // coin floating up and down
        if (invertMovement)
        {
            platform.Translate(new Vector3(0, moveDistance / setTime, 0) * Time.deltaTime);
        }
        else
        {
            platform.Translate(new Vector3(0, -moveDistance / setTime, 0) * Time.deltaTime);
        }

        //Built in Timer to invert movement
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            invertMovement = !invertMovement;
            timer = setTime;
        }
    }
}
