using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;

    private int score;
    private GameObject goal;
    //private bool sceneIsChanged;
    private bool resync;

    // Bugfixing
    private float loadingTime = 0.2f;
    private float loadTimer;

    void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = Text.FindObjectOfType<Text>();
        //goal = GameObject.FindGameObjectWithTag("Goal");
        //goal.SetActive(false);

        //Bugfixing
        initObjects();
        resync = false;
        loadTimer = loadingTime;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!resync)
        {
            if (GameObject.FindGameObjectsWithTag("Collectible").Length <= 0)
            {
                goal.SetActive(true);
            }
            if (scoreText != null)
            {
                scoreText.text = "Points: " + score;
                if (GameObject.FindGameObjectsWithTag("Collectible").Length <= 0)
                {
                    goal.SetActive(true);
                }
            }
        }
        else
            wait();
    }

    public void increaseScore()
    {
        score += 50;
    }

    public void loadToggle()
    {
        resync = true;
    }

    // Bugfixing
    public void wait()
    {
        if(loadTimer > 0)
        {
            loadTimer -= Time.deltaTime;
        }
        else
        {
            initObjects();
            resync = false;
            loadTimer = loadingTime;
        }
    }

    public void initObjects()
    {
        scoreText = Text.FindObjectOfType<Text>();
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.SetActive(false);
    }    


}
