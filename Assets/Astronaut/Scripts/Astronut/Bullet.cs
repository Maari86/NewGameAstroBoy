using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] private AudioClip alien;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            SoundManager.instance.PlaySound(alien);
            ScoreCounter.scoreValue += 10;
            // Disable or destroy the enemy game object
            other.gameObject.SetActive(false);
            // Or: Destroy(other.gameObject);

            // Destroy the bullet game object
            Destroy(gameObject);
        }
        else if (other.CompareTag("Gems"))
        {
            // Find the player object and get its PlayerHealth component
            GameObject Astronut = GameObject.FindGameObjectWithTag("Player");
            Health playerHealth = Astronut.GetComponent<Health>();

            // If the player has a PlayerHealth component, take damage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destroy the gems game object
            Destroy(other.gameObject);

            // Destroy the bullet game object
            Destroy(gameObject);
        }
    }
}

