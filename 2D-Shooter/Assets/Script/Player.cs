using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    
    // movement
    public float playerSpeed;
    private Vector2 movement;
    
    // health
    public float playerHealth;
    public float damageTakenValue;
    
    // rotate player to move position
    public float offset;
    
    // weapon
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Update()
    {
        timeBetweenShots = timeBetweenShots - Time.deltaTime;
        
        // movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        
        // rotation
        var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBetweenShots <= 0)
        {
            // shooting
            if (Input.GetMouseButtonDown(0))
            {
                print("shoot");
                Instantiate(projectile, projectileSpawnPoint.position, transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }
        }
    }

    private void FixedUpdate()
    {
        // movement register
        rigidBody.MovePosition(rigidBody.position + movement * (playerSpeed * Time.fixedDeltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth = playerHealth - damageTakenValue;
        }
    }
}
