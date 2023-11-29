using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSystem: MonoBehaviour
{
    private Camera Cam;
    [SerializeField] private PlayerBulletMovement bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 5f; 
    //public KeyCode fireKey = KeyCode.Space;
    [SerializeField,Range(1,100)] private float rotationSpeed=1;
    void Awake()
    {
        Cam=Camera.main;
    }
    void Update()
    {
        var mousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        transform.up = Vector3.MoveTowards(transform.up, mousePosition, rotationSpeed*Time.deltaTime);
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity).Init(transform.up);
        }
    }

    void ShootBullet()
    {
        // Instantiate a new bullet from the bullet prefab
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = (mousePosition - firePoint.position).normalized;

        //Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        //bulletRigidbody.velocity = direction * bulletSpeed;

        // Calculate the rotation angle from direction
        //float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
    }
}

