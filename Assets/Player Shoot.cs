using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float _nextShotTime;
    
    [SerializeField] private GameObject projectile1Prefab;
    [SerializeField] private GameObject projectile2Prefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireCooldown = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot(projectile1Prefab);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Shoot(projectile2Prefab);
        }
    }

    private void Shoot(GameObject projectilePrefab)
    {

        if (Time.time < _nextShotTime)
        {
            return;
        }

        _nextShotTime = Time.time + fireCooldown;

        if (firePoint == null)
        {
            firePoint = transform;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = ((Vector2)mouseWorldPosition - (Vector2)firePoint.position).normalized;
        if (direction == Vector2.zero)
        {
            direction = Vector2.right;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0f, 0f, angle));
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }
}
