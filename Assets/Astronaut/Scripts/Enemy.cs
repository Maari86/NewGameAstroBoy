using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Define a public variable to hold the bullet prefab
    public GameObject bulletPrefab;

    // Called when the object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the enemy game object
            Destroy(gameObject);

            // Destroy the bullet game object
            Destroy(collision.gameObject);
        }
    }
}

