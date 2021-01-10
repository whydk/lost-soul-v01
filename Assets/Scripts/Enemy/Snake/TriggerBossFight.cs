using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    public GameObject boss;
    public GameObject hpBar;
    public Vector3 location;
    public Collider bossDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bossDoor.enabled = false;
            Instantiate(boss);
            boss.transform.position = location;
            hpBar.SetActive(true);
            hpBar.GetComponent<HealthBarSnake>().snake = GameObject.Find("SnakeBoss(Clone)");
            FindObjectOfType<GameManager>().BossMusic();
            Destroy(gameObject);
        }


    }
}
