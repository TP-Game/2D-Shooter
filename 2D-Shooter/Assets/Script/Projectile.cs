using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    public float projectileLifeTime;

    private void Start()
    {
        ProjectileLifeTime();
    }

    private void Update()
    {
        // Projectile Movement
        transform.Translate(Vector2.up * (projectileSpeed * Time.deltaTime));
    }

    private void ProjectileLifeTime()
    {
        Destroy(gameObject,projectileLifeTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
