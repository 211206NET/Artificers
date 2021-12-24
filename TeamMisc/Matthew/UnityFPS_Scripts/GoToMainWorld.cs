using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoToMainWorld : MonoBehaviour
{


    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            //transform.Translate(Vector3.forward * (Time.deltaTime*moveSpd));
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        //Scene scene = SceneManager. GetActiveScene(); 
        //SceneManager.LoadScene(scenePaths2[1], LoadSceneMode.Single);
        var pos = GameObject.Find("Player").transform;
        pos.position = new Vector3(664f,124f,425f);
        SceneManager.LoadScene(1);
    }

}
