using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderPoints : MonoBehaviour
{
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        int ValueScore = 5;

        FindObjectOfType<GameSession>().AddToScore(ValueScore);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        Destroy(otherObject.gameObject);
    }
}
