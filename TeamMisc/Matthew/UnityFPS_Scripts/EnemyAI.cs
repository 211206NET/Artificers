using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //AI Stats
    #region Stats
    public int hP = 100;
    public int maxHP = 100;
    public float seeDis = 40.0f; //How far this AI can see
    public float moveSpd = 5.0f; //How fast the AI moves
    public float dmg = 10.0f; //How much damage this AI does per attack
    public float atkSpd = 900.0f; //How fast enemy attacks (60f = 1 attack per second)
    public float atkRng = 1f; 
    #endregion  

    //AI Mechanics
    #region Mechanics

    //public gameobject playerObj; 

    //Internal Variables
    private float finalDmg;
    private int ffDmg;
    private bool cSee = false; //If can see player and player in see range
    private float seeCheckTime = 10.0f;
    private float seeCheckCD = 0.0f; //How frequently the AI looks to see if player can be seen

    #endregion  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Return if can see player
    bool CanSee()
    {   
        var pos = GameObject.Find("Player").transform;//.position;
        //var hit : RaycastHit;  
        RaycastHit hit = new RaycastHit();
        var rayDirection = pos.position - transform.position;
        if (Physics.Raycast (transform.position, rayDirection, out hit)) {
            if (hit.transform == pos) {
                //Also check if player is within range
                if(Vector3.Distance (pos.transform.position, transform.position)<seeDis)
                {
                    // enemy can see the player!
                    return true;
                }
                else
                {
                    return false;
                }
            } else {
                // there is something obstructing the view
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Return if player is within AI attack range
    bool AtkRange()
    {
        var pos = GameObject.Find("Player").transform;//.position;
        if(Vector3.Distance (pos.transform.position, transform.position)<atkRng)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Attack player
    void Attack()
    {
        var pos = GameObject.Find("Player").GetComponent<PlayerScript>();
        finalDmg = dmg+Mathf.Round(Random.Range(finalDmg*0.8f, finalDmg*1.2f));
        ffDmg = (int) finalDmg;
        pos.hP -= ffDmg;
    }

    //Close in on player to attack
    void MoveIn()
    {
        float angle = 90;
        var pos = GameObject.Find("Player").transform;//.position;

        //Move
        if ( Vector3.Angle(pos.forward, transform.position - pos.position) < angle) 
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            if(Vector3.Distance (pos.transform.position, transform.position)>4)
            {
                agent.destination = pos.position;
                agent.speed = moveSpd;
            }
            else
            {
                //agent.destination = transform.position;
                agent.speed = 1; //Slow down as getting closer to player
            }
            //transform.Translate(Vector3.forward * (Time.deltaTime*moveSpd)); //old non-navmesh way
        }

    }

    void Stop()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = transform.position;
        agent.speed = 0;
    }

    //Close in on player to attack
    void FacePlayer()
    {
        var damping = 2;
        var pos = GameObject.Find("Player").transform.position;
        var lookPos = pos - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping); 
    }

    //The Enemy has run out of HP, delete it
    void Die()
    {
        //For now...
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update() //Supposed to be 60/second but tests as 225/second
    {
        //Routinely check to see if player and AI have LOS and player is in see range
        if(seeCheckCD < 1)
        {
            cSee = CanSee();
            seeCheckCD = seeCheckTime; //Set CD again
        }
        if(seeCheckCD > 0){seeCheckCD--;}

        //Routinely check to see if AI can attack player
        if(cSee)
        {
            if(AtkRange())
            {
                Attack();
                Stop();
            }
            else
            {
                FacePlayer();
                MoveIn();
            }
        }

        if(hP < 1)
        {
            Die();
        }
    }
}
