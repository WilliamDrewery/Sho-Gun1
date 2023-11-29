using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletBody;
    [SerializeField] private float bulletSpeed;
    public void Init(Vector2 dir)
    {
        Vector2 rotatedDir = new Vector2(dir.y, -dir.x);
        bulletBody.velocity = rotatedDir * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }

    }
    void Update()
    {

    }
}