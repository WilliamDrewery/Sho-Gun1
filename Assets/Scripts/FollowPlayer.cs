using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followSpeed;
    public GameObject Weapon;
    public Transform Player;


    // Update is called once per frame
    void Update()
    {
        Vector2 position = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouse = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(position, mouse);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle-180));
        //this code rotates the weapon towards the position of the mouse
        //the basis of the code was created by BenZed on Unity answers

        Weapon.transform.SetParent(Player.transform);
       
        
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
}
