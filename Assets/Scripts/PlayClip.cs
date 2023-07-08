using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClip : MonoBehaviour
{
    public AudioClip clipToPlay; 
    private AudioSource audioSource;
    private float timer = 0f;
    private float minInterval = 3f;
    private float maxInterval = 6f;
    private float interval;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clipToPlay;
        interval = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            PlayClipRandomly();
            timer = 0f;
            interval = Random.Range(minInterval, maxInterval);
        }
    }

    private void PlayClipRandomly()
    {
        AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
    }
}

