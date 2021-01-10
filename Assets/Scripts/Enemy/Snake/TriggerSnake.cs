using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSnake : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GAMEMANAGER").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Attack"))
        {
            Debug.Log(collision.gameObject.name + " hit " + gameObject.name);
            gameObject.transform.position += new Vector3(1f, 0f, 0f);
            EnemyHealth snake = gameObject.GetComponent<EnemyHealth>();
            snake.TakeDamage(1);
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<Knockback>().knockBackEnabled == true)
        {
            Debug.Log(gameObject.name + " trigger " + other.name);
            gameManager.DamagePlayer(1);
        }

    }
}
