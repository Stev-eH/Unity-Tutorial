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
    private bool sceneIsChanged; 

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
        scoreText = Text.FindObjectOfType<Text>();
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.SetActive(false);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneIsChanged)
        {
            goal = GameObject.FindGameObjectWithTag("Goal");
            goal.SetActive(false);
        }
        scoreText = Text.FindObjectOfType<Text>();
        if (scoreText != null)
        {
            scoreText.text = "Points: " + score;
            if (GameObject.FindGameObjectsWithTag("Collectible").Length <= 0)
            {
                goal.SetActive(true);
            }
        }
    }

    public void increaseScore()
    {
        score += 50;
    }

    public void loadToggle()
    {
        sceneIsChanged = true;
    }


}
