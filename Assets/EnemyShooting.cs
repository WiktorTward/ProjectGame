// EnemyShooting.cs
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10.0f;

    private float nextFireTime = 0.0f;

    public void Shoot(Vector3 targetPosition)
    {
        if (Time.time > nextFireTime)
        {
            // Tworzymy obiekt pocisku z prefabrykatu na okre�lonym punkcie spawnu
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Obliczamy kierunek strza�u
            Vector3 shootDirection = (targetPosition - bulletSpawnPoint.position).normalized;

            // Nadajemy pr�dko�� pociskowi
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;

            // Tutaj mo�esz doda� dodatkow� logik� dla pocisku, na przyk�ad ustawienie obra�e� itp.

            nextFireTime = Time.time + 1.0f; // Ustawiamy czas do kolejnego strza�u
        }
    }
}
