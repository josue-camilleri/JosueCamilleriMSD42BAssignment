using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        int ValueScore = 5;

        FindObjectOfType<GameSession>().AddToScore(ValueScore);

        Destroy(otherObject.gameObject);
    }
}
