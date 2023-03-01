using UnityEngine;

public class Energyball : MonoBehaviour
{
    public int damage = 10; // The amount of damage the player takes when the object collides with them

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
