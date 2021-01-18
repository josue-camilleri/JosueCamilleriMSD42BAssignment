using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] AudioClip playerPointSound;
    [SerializeField] [Range(0, 1)] float playerPointSoundVolume = 0.75f;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        AudioSource.PlayClipAtPoint(playerPointSound, Camera.main.transform.position, playerPointSoundVolume);
    }
}
