using System.Collections;
using System.Collections.Generic;
using FPS.Interfaces;
using FPS.Managers.Bullet;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamageable
{
    [SerializeField] private BulletSettings bulletSettings;
    
    public float health;

    public void OnDamage()
    {
        health -= bulletSettings.bulletDamage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Gun daki check i buradan yapip sadece orada bir bu func ile check edicem (Temp health gidiyor) //TODO
    public bool isDeadCalcute(float damage)
    {
        return health - damage > 0;
    }
}
