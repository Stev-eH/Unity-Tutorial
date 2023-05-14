using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine.SceneManagement holds libraries to switch between scenes
using UnityEngine.SceneManagement;

public class GoalTeleporter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ResetPosition();
            //Debug.Log("Entered");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().toggleResync();

            /*buildIndex: when planning out the levels in a game, all used scenes need to be added in the build settings
            (File > Build Settings... > Scenes in build)
             When you add a scene here it gets assigned a scene ID, which in this example will be used to switch between the scenes
             In this example we load the scene with the buildIndex of the current scene +1*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //This example will load a scene by its name
            //Also has to be added in the Build Settings beforehand
            //SceneManager.LoadScene("Level 2");
        }
    }
}
