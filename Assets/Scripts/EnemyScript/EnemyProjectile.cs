using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float timeToShoot;
    public float shootCooldown;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= Time.deltaTime;
        //if(shootCooldown < 0)
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
        GameObject fireball = Instantiate(projectile, transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f), ForceMode2D.Force);
        }
        else
        {
            fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f), ForceMode2D.Force);
        }
        shootCooldown = timeToShoot;
        Destroy(fireball, 3f);
    }
}
