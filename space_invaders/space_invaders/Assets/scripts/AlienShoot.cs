using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float minShootTime = 2f;
    public float maxShootTime = 5f;

    void Start()
    {
        Invoke("Shoot", Random.Range(minShootTime, maxShootTime));
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Invoke("Shoot", Random.Range(minShootTime, maxShootTime));
    }
}
