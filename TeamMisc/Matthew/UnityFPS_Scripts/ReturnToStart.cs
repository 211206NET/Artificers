using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ReturnToStart : MonoBehaviour
{

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        //Scene scene = SceneManager. GetActiveScene(); 
        //SceneManager.LoadScene(scenePaths2[1], LoadSceneMode.Single);
        var pos = GameObject.Find("Player").transform;
        pos.position = new Vector3(18f,4f,20f);
        SceneManager.LoadScene(0);
    }

}
