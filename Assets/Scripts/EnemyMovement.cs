using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    [SerializeField] float speed;
    private float distance;
    //private int enemyMoveTrigger;
    [SerializeField] TextMeshProUGUI scoreText;
    public float score = 0;

    void Update()
    {
        //enemyMoveTrigger = FindObjectOfType<moveTrigger>().RoomTrigger.RoomTriggerVar();
        //if (enemyMoveTrigger==1)
        //{
            Move();
        //}
        
    }
 
    void Move()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            Destroy(gameObject);
            score += 100;
            scoreText.text = score.ToString();
            if (enemy.gameObject.tag == "Boss")
            {
                score += 900;
                scoreText.text = score.ToString();
            }
        }

    }
}
