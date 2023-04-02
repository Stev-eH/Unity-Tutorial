using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFloat : MonoBehaviour
{
    Transform coin;

    public float moveDistance;
    
    bool invertMovement;
    float timer;
    const float setTime = 1f;

    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<Transform>();
        invertMovement = false;
        timer = setTime;
        moveDistance = 0.2f;

        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        // coin floating up and down
        if(invertMovement)
        {
            coin.Translate(new Vector3(0, moveDistance, 0) * Time.deltaTime);
        }
        else
        {
            coin.Translate(new Vector3(0, -moveDistance, 0) * Time.deltaTime);
        }

        //Built in Timer to invert movement
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            invertMovement = !invertMovement;
            timer = setTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // a script is also a component to a GameObject, we can call functions of different scripts liks this
            gameController.GetComponent<GameLogic>().increasePoints();

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioPlayer>().playCoinPickupSFX();

            // dostroys the corresponding GameObject
            Destroy(this.gameObject);
        }
    }
}
