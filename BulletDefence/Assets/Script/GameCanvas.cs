using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] Slider playerHealth;
    [SerializeField] Slider enemyHealth;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject winPanel;
    [SerializeField] Text winner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerHealth()
    {
        playerHealth.value -= 20;

        if (playerHealth.value <= 0)
        {
            winPanel.SetActive(true);
            winner.text = "~~~~~LOSE~~~~~";
        }
    }

    public void SetEnemyHealth()
    {
        enemyHealth.value -= 20;

        if (enemyHealth.value <= 0)
        {
            winPanel.SetActive(true);
            winner.text = "~~~~~Winner~~~~~";
            Destroy(enemy);
        }
    }
}
