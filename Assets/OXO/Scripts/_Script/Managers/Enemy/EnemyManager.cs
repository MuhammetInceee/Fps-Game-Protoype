using System.Collections;
using System.Collections.Generic;
using FPS.Managers.Bullet;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [FoldoutGroup("References")] [SerializeField] private BulletSettings bulletSettings;
    
    [SerializeField] private ClothesHolder[] clothesHolder;

    [SerializeField] private float health;

    public void OnDamage()
    {
        health -= bulletSettings.bulletDamage;
        if (health <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        
    }

}
