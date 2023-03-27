using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour 
{
    static int points;
    public Text scoreText;
    public GameObject canvas;
    private GameObject goal;
    private int leftToCollect;

    private bool playGoal;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // object  persists when switching scenes
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("UI"));
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        leftToCollect = GameObject.FindGameObjectsWithTag("Collectible").Length;
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.SetActive(false);
        playGoal= true;
    }

    // Update is called once per frame
    void Update()
    {
        leftToCollect = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Debug.Log(leftToCollect);

        scoreText.GetComponent<Text>().text = "Score: " + points;

        if(leftToCollect <= 0)
        {
            goal.SetActive(true);
            if (playGoal)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioPlayer>().playGoalSFX();
                playGoal = false;
            }
        }
    }

    

    public void increasePoints()
    {
       points += 50;
    }
}
