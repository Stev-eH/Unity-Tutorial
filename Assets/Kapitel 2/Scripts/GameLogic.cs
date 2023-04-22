using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine.UI needs to be used to change text on UI Elements
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour 
{
    private int points;

    public Text scoreText;
    private GameObject goal;

    // this variable holds how many coins there are still left in a scene
    private int leftToCollect;

    // switch to only play the goalAppearing Sound effect one time
    private bool playGoalSFX;

    public static bool resync;
    public float resyncTime = 1f;
    public float timeHolder;

    void Awake()
    {
        // !!IMPORTANT!! use of FindGameObjectsWithTag
        // returns an array of all GameObjects with the supplies tags
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        // this checks if there is currenty another GameController in the active scene
        if (objs.Length > 1)
        {
            // if that is the case, this GameObject will destroy itself and there will only ever be one active GameController
            Destroy(this.gameObject);
        }

        // DontDestroyOnLoad: object persists when switching scenes
        // has the effect that our score does not reset between changin levels
        DontDestroyOnLoad(this.gameObject);


    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        resync = false;
        initObjects();
        timeHolder = resyncTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!resync)
        {
            // since ..GameObjectsWithTag returns an array we can simply check the length of the array to get the number of active coins/collectibles in a scene
            leftToCollect = GameObject.FindGameObjectsWithTag("Collectible").Length;

            //Debug.Log(leftToCollect);

            // if there are no collectibles left we will make the goal appear
            if (leftToCollect <= 0)
            {
                if (goal != null)
                {
                    goal.SetActive(true);
                }
                if (playGoalSFX)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioPlayer>().playGoalSFX();
                    playGoalSFX = false;
                }
            }
        }

        else
        {
            if(timeHolder > 0)
            {
                timeHolder -= Time.deltaTime;
            }
            else
            {
                initObjects();
                timeHolder = resyncTime;
                resync = false;
            }
        }
    }
      public void increasePoints()
    {
       points += 50;
       scoreText.GetComponent<Text>().text = "Score: " + points;
    }

    public void initObjects()
    {
        goal = GameObject.FindGameObjectWithTag("Goal");

        if (goal != null)
        {
            goal.SetActive(false);
        }
        playGoalSFX = true;

        scoreText = Text.FindObjectOfType<Text>();
    }

    public void toggleResync()
    {
        resync = true;
    }
}
