using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSnake : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public GameObject snake;

    // Update is called once per frame
    void Update()
    {
        currentHealth = snake.GetComponent<EnemyHealth>().health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = halfHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }

    }
}
