using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameCanvas gameCanvas;
    GameObject player;
    GameObject enemy;
    public float bulletSpeed;
    bool shotPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        gameCanvas = FindObjectOfType<GameCanvas>();
    }


    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (shotPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, bulletSpeed * Time.deltaTime);
        }
        else
        {
            if (enemy != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, bulletSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defence"))
        {
            shotPlayer = false;
        }
        if (other.CompareTag("Player"))
        {
            gameCanvas.SetPlayerHealth();
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            gameCanvas.SetEnemyHealth();
            Destroy(gameObject);
        }
    }
}
