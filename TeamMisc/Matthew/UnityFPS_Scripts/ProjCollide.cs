using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjCollide : MonoBehaviour
{
    //AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (collision.gameObject.tag == "EnemyTag"){
                var trgt = collision.gameObject.GetComponent<EnemyAI>();
                trgt.hP -= 50;
                Destroy(gameObject);
            }
        //}
        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();
    }
}