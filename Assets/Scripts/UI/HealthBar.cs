using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GameManager gameManager;
    public int currentHealth;
    public int maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;

    private void Awake()
    {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
        
    }
    private void Update()
    {
        maxHealth = gameManager.Player.GetComponent<PlayerHealth>().maxHealth;
        currentHealth = gameManager.Player.GetComponent<PlayerHealth>().currentHealh;
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
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
