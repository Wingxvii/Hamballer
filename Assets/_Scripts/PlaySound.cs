using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Play() {
        sound.Play(0);
    }



}
