using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    private float rand;
    void Start()
    {
        rand = Random.Range(1.0f, 3.0f);
        spawner1 = GameObject.FindWithTag("S1");
        spawner2 = GameObject.FindWithTag("S2");
        spawner3 = GameObject.FindWithTag("S3");
        spawner4 = GameObject.FindWithTag("S4");
        StartCoroutine(SpawnLoop());
        StartCoroutine(SpawnLoop2());
    }

    private IEnumerator SpawnLoop()
    {
        WaitForSeconds waitTime = new WaitForSeconds(rand);
        while (true)
        {
            SpawnBullet();
            waitTime = new WaitForSeconds(Random.Range(1.0f, 4.0f));
            yield return waitTime;
        }
    }

    private IEnumerator SpawnLoop2()
    {
        WaitForSeconds waitTime = new WaitForSeconds(rand);
        while (true)
        {
            SpawnBullet2();
            waitTime = new WaitForSeconds(Random.Range(1.0f, 4.0f));
            yield return waitTime;
        }
    }

    void SpawnBullet()
    {
        GameObject Clone1 = Instantiate(Bullet, spawner1.transform.position, Quaternion.identity);
        GameObject Clone2 = Instantiate(Bullet, spawner2.transform.position, Quaternion.identity);
    }

    void SpawnBullet2()
    {
        GameObject Clone3 = Instantiate(Bullet, spawner3.transform.position, Quaternion.identity);
        GameObject Clone4 = Instantiate(Bullet, spawner4.transform.position, Quaternion.identity);
    }
}
