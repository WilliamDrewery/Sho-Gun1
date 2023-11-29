using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    public int playerHealth = 100;
    public int timeCounter = 5;
    Vector2 Movement;
    //private GunFire Gun;
    Rigidbody2D playerRigidbody;
    float inputHorizontal;
    [SerializeField] TextMeshProUGUI healthText;
    //Defining objects in the unity engine
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Run();
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        //This swaps the player sprite depending on the direction their moving

    }
    void Awake()
    {
    }
    void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }
    public void Run()
    {
        Vector2 playerVelocity = new Vector2(Movement.x * movementSpeed, Movement.y * movementSpeed);
        playerRigidbody.velocity = playerVelocity;
        //creating a movement vector
       
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            playerHealth -= 5;
            healthText.text = (playerHealth.ToString()+"/100");

        }
        else if(collision.gameObject.tag == "Enemies")
        {
            playerHealth -= 1;
            healthText.text = (playerHealth.ToString() + "/100");
        }
        //If the player collides with an enemy or their bullets, they loose health
        if (playerHealth<=0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    
}
