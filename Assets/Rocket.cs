using UnityEngine;

public class Rocket : Projectile
{
    [SerializeField] private float radius = 1f; // range of the explosion

    private void DamageNearbyEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in hits)
        {
            Enemy nearbyEnemy = collider.GetComponent<Enemy>();
            if (nearbyEnemy != null)
            {
                nearbyEnemy.TakeDamage(damage);
            }
        }
    }

    public override void OnEnemyHit(Enemy enemy)
    {
        DamageNearbyEnemies();
        Destroy(gameObject);
    }

    public override void OnWallHit()
    {
        DamageNearbyEnemies();
        Destroy(gameObject);
    }
}
