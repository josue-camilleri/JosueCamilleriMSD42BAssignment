using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int wave1 = 1;
    [SerializeField] int wave2 = 2;
    [SerializeField] int wave3 = 3;
    [SerializeField] int wave4 = 4;
    [SerializeField] int wave5 = 5;
    [SerializeField] int bullet = 1;

    //returns the amount of damage
    public int wave1Damage()
    {
        return wave1;
    }

    public int wave2Damage()
    {
        return wave2;
    }

    public int wave3Damage()
    {
        return wave3;
    }

    public int wave4Damage()
    {
        return wave4;
    }

    public int wave5Damage()
    {
        return wave5;
    }

    public int bulletDamage()
    {
        return bullet;
    }

    //destroys gameObject
    public void Hit()
    {
        Destroy(gameObject);
    }
}
