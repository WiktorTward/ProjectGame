using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float lifeTime = 3f;
    public Vector2 bulletDirection = Vector2.one;

    void Update()
    {  
        if (Input.GetAxisRaw("Horizontal")!= 0 || Input.GetAxisRaw("Vertical") != 0) 
        {
            bulletDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (bulletDirection.y >= 0) //gora
        {
            bullet.transform.Rotate(0, 0, 0);
        }
        if (bulletDirection.y >= 0 || bulletDirection.x >= 0)
        {
            bullet.transform.Rotate(0, 0, -45);
        }
        if (bulletDirection.y >= 0 || bulletDirection.x <= 0) 
        {
            bullet.transform.Rotate(0, 0, 45);
        }
        if (bulletDirection.x >= 0)//prawo
        {
            bullet.transform.Rotate(0, 0, 90);
        }
        if (bulletDirection.y <= 0 || bulletDirection.x >= 0)
        {
            bullet.transform.Rotate(0, 0, 45);
        }
        if (bulletDirection.x <= 0)//lewo
        {
            bullet.transform.Rotate(0, 0, 90);
        }
        if (bulletDirection.y <= 0 || bulletDirection.x <= 0) 
        {
            bullet.transform.Rotate(0, 0, -45);
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletDirection *  bulletForce ,ForceMode2D.Impulse);
        StartCoroutine(SelfDestruct(bullet));
    }
    IEnumerator SelfDestruct(GameObject bullet)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(bullet);
    }
}
