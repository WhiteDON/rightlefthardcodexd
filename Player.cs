using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public GameObject t1;
   public GameObject t2;
   bool check;
   public AudioClip[] sounds;
   public Game GameHolder;
   public void Update()
   {
       if(check)
       {
           transform.position = Vector3.MoveTowards(transform.position,t1.transform.position, 4f * Time.deltaTime);
       }
       if(!check)
       {
           transform.position = Vector3.MoveTowards(transform.position,t2.transform.position, 4f * Time.deltaTime);
       }
   }
   public void CheckUpdate()
   {
       check = !check;
       GetComponent<AudioSource>().clip = sounds[0];
       GetComponent<AudioSource>().Play();
   }
   public void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag == "enemy")
       {
       GameHolder.Death();
       GameHolder.Alive = false;
       }
       else if (other.gameObject.tag == "bonus")
       {
           GameHolder.ScoreAdd();
           Destroy(other.gameObject);
       }
       
   }
   
}
