using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
    }
}
