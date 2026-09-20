using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float damage = 1f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Handle player collision
        }
    }
}
