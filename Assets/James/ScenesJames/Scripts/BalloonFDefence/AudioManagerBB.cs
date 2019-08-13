using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerBB : MonoBehaviour
{
    public AudioClip gameStart;
    public AudioClip slowTime;
    public AudioClip hpRegen;
    public AudioClip rapidFire;
    public AudioClip metalHit;
    public AudioClip balloonHit;
    public AudioClip crossBowFire;
    public AudioClip crossBowReload;
    public AudioClip gateAttack;

    private AudioSource audioPlayerSource;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayerSource = GetComponent<AudioSource>();
    }

    
}
