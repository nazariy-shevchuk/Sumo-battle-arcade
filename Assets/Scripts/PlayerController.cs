using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    private float powerupStrength = 15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            
            Destroy(other.gameObject);
            
            StartCoroutine(PowerupCountdownRoutine());  // Start the coroutine
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;  // Get direction away from the player

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);   // Apply powerup force to enemy
            
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
