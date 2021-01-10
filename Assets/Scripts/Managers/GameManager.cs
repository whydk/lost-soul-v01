using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public List<GameObject> Enemies;
    public Animator[] animators;
    public AudioClip[] music;

    private void Awake()
    {
        GetComponent<AudioSource>().Play();
    }
    public void BossMusic()
    {
        GetComponent<AudioSource>().clip = music[1];
        GetComponent<AudioSource>().Play();
    }

    void AddEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Enemies.Add(enemy);
        }
    }
    public void RemoveEnemy(GameObject enemy)
    {
        Enemies.Remove(enemy);
    }
    public void DamagePlayer(int damage)
    {
        Player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
    public void FindAnimators()
    {
        animators = FindObjectsOfType(typeof(Animator)) as Animator[];
    }
}
