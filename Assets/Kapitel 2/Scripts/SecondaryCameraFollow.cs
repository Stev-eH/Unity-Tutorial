using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryCameraFollow : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] mainCameras = GameObject.FindGameObjectsWithTag("MainCamera");

        if(mainCameras.Length >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
