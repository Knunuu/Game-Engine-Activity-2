using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected bool strongProjectile = false; //if true, this projectile can open strong doors

    private void Update()
    {
        if (_direction != Vector2.zero)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.right = _direction.normalized;
        transform.position += (Vector3)(_direction.normalized * speed * Time.deltaTime);
    }

    public virtual void OnEnemyHit(Enemy enemy)
    {
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    public virtual void OnWallHit()
    {
        Destroy(gameObject);
    }

    public virtual void OnDoorHit(Door door)
    {
        Destroy(gameObject);

        if (door != null && !door.GetIsOpen())
        {
            if (strongProjectile && door.GetStrongDoor())
            {
                door.OpenDoor();
            }
            else if (!door.GetStrongDoor())
            {
                door.OpenDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Projectile hit an enemy");

            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                OnEnemyHit(enemy);
            }
        }
        else if (collision.CompareTag("Wall"))
        {
            Debug.Log("Projectile hit an obstacle");

            OnWallHit();
        }
        else if (collision.CompareTag("Door"))
        {
            Debug.Log("Projectile hit a door");
            Door door = collision.transform.root.GetComponent<Door>();
            OnDoorHit(door);
        }
    }

    public Vector2 SetDirection(Vector2 angle)
    {
        _direction = angle.normalized;
        if (_direction != Vector2.zero)
        {
            float zRotation = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        }
        return _direction;
    }

    public Vector2 GetDirection() => _direction;

    public float GetSpeed() => speed;

    public float GetDamage() => damage;

    public bool IsStrongProjectile() => strongProjectile;
}
