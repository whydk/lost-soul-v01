using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public List<string> soundNamesWalk;
    public string playerHit;
    public string sword;
    public string meleePlayer;

    AudioManager am;
    PlayerControl pc;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        pc = GetComponent<PlayerControl>();
    }
    public void PlayRandomWalkSound()
    {
        am.Play(soundNamesWalk[Random.Range(0, soundNamesWalk.Count)]);
    }
    public void PlayAttackSound()
    {
        if (pc.hasSword)
        {
            am.Play(sword);
        }
        else
        {
            am.Play(meleePlayer);
        }
    }
    public void PlayerHitSound()
    {
        am.Play(playerHit);
    }
}
