using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 1f;

    private void Update()
    {
        if (_direction != Vector2.zero)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    public virtual void OnEnemyHit(GameObject enemy)
    {
        //deal damage
        Destroy(gameObject);
    }

    public virtual void OnWallHit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                OnEnemyHit(collision.gameObject);
            }
        }
        else if (collision.CompareTag("Obstacle"))
        {
            OnWallHit();
        }
    }

    public Vector2 SetDirection(Vector2 angle) => direction = angle;

    public Vector2 GetDirection() => direction;

    public float GetSpeed() => speed;

    public float GetDamage() => damage;

    
}
