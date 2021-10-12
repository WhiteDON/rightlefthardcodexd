using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject[] t;
    int index;
    GameObject currentPoint;
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentPoint.transform.position, 6f * Time.deltaTime);
        transform.Rotate(0.0f, 0.0f, 100f * Time.deltaTime);   
    }
    public void Start()
    {
        t = GameObject.FindGameObjectsWithTag("point");
        index = Random.Range (0, t.Length);
        currentPoint = t[index];
    }
     public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "DestroyEnemy")
        {
         Destroy(this.gameObject);
        }
    }
   
}
