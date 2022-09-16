using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody enemyRb; 
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Set enemy direction towards player and move there
        Vector3 lookDirecrtion = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirecrtion * speed);

        // Destroy enemys out of scene
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
