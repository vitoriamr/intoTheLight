using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    private GameObject lastSky;

     // Start is called before the first frame update
    void Start()
    {
        lastSky = GameObject.FindWithTag("Finish");    
    }

    // Update is called once per frame
    void Update()
    {
        if(!lastSky.GetComponent<Renderer>().isVisible) {
            transform.Translate(0, Time.deltaTime, 0, Space.World);
        } else {
            SceneManager.LoadScene("win");
        }
    }
}
