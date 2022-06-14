using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform shootPiont;
    [SerializeField] GameObject spiderBullet;
    [SerializeField] float timeBetweenShots;
    float nextShotTime;
    [SerializeField] float bulletForce;
    [SerializeField] float aggroDistance;

    Rigidbody2D enemyRb;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < aggroDistance)
        {
            EnemyLookTowardsPlayer();

            if (Time.time > nextShotTime)
            {
                Shoot();

                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(spiderBullet, shootPiont.position, shootPiont.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootPiont.up * bulletForce, ForceMode2D.Impulse);
    }

    void EnemyLookTowardsPlayer()
    {
        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        enemyRb.rotation = angle;
    }
}
