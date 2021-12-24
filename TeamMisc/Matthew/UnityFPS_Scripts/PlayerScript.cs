using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

#if UNITY_EDITOR
    using UnityEditor;
    using System.Net;
#endif

public class PlayerScript : MonoBehaviour
{
    //Player Stats
    [Header("Stats")]
    #region Stats
    public int hP = 100; 
    public int maxHP = 100;
    public int dmg = 10; //How much damage this Player does per attack
    public float atkSpd = 60.0f; //How fast Player attacks (60f = 1 attack per second)
    public float atkRng = 1.0f; 
    #endregion  

    //Mechanics
    #region Mechanics
    public GameObject magicAtkA;
    public GameObject Gem; //Position of Gem of magic staff
    public float launchVelocity = 700f;

    //Internal Variables
    //private float atkCheckCD = 0.0f; //How frequently the Player attacks, set by atkSpd


    //private AssetBundle myLoadedAssetBundle;
    //private string[] scenePaths2;

    #endregion  


    private static PlayerScript _instance;
    public bool SingletonMode = true;

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //DontDestroyOnLoad(this.gameObject); //Makes player persistant: Now handled with singleton class

        
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        //scenePaths2 = myLoadedAssetBundle.GetAllScenePaths();
        //ChangeScene();
    }

    void Awake(){
        if(SingletonMode == true)
        {
            if (_instance == null){ //Use Singleton mode
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
        
                //Rest of Awake code here
        
            } else {
                Destroy(gameObject);
            }
        }
        else{DontDestroyOnLoad(this.gameObject);} //Don't use singleton mode and just make the player persistant
    }

    //Shoot a magic projectile forward
    void Shoot()
    {
        GameObject magicAtk = Instantiate(magicAtkA, Gem.transform.position,Gem.transform.rotation);
        magicAtk.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*launchVelocity);
    }

    //The Player has run out of HP, restart game for now...
    void Die()
    {
        //For now...
        //Application.LoadLevel(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene("Sample Scene").name);
        
        //SceneManager.LoadScene("Sample Scene");
        //Scene scene = SceneManager.GetActiveScene(); 
        //SceneManager.LoadScene(scene.name);
    }

    void ChangeScene()//Depreciated
    {
        //Scene scene = SceneManager. GetActiveScene(); 
        //SceneManager.LoadScene(scenePaths2[1], LoadSceneMode.Single);
        transform.position = new Vector3(664f,124f,425f);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {Shoot();}

        if(hP < 1)
        {Die();}
    }
}
