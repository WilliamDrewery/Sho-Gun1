using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //public Transform EnemyPos;
    [SerializeField] public GameObject BulletPrefab;
    public float BulletSpeed = 1f;
    public Transform spawn;
    public float fireRate = 2f;
    public float fireTime = 0f;
    private Transform player;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
        fireTime += Time.deltaTime;
        if (fireTime >= fireRate)
        {
            GameObject bullet = Instantiate(BulletPrefab, spawn.position, Quaternion.identity);
            fireTime = 0f;
        }
            
        
    }
    
    

}
