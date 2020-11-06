using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float bulletWaited;
    Vector3 targetPos;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = RandNewPos();
    }

    private void Awake()
    {
        StartCoroutine(BulletGenerator());
    }

    void FixedUpdate()
    {
        Walk();
    }

    Vector3 RandNewPos()
    {
        float newX = Random.Range(-4, 4);
        float newZ = Random.Range(-4, 4);

        return new Vector3(newX, transform.position.y, newZ);
    }

    void Walk()
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * enemySpeed);
        }
        else
        {
            targetPos = RandNewPos();
        }
    }

    IEnumerator BulletGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletWaited);
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            Instantiate(bullet, newPos, Quaternion.identity);
        }
    }
}