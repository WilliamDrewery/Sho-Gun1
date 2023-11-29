using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float BulletSpeed = 1f;
    private Transform player;
    private Vector2 target;
    //public GameObject target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.transform.position;

    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position,target , BulletSpeed * Time.deltaTime);
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag=="Map"|| collision.gameObject.tag == "Player") 
        {
            //if the bullet collides with anything in the game world, it will disappear
            Destroy(gameObject);
        }
       else if (collision.gameObject.tag == "EnemyBullet")
        {
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
