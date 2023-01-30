using System;
using System.Collections;
using System.Collections.Generic;
using FPS.Interfaces;
using UnityEngine;

namespace FPS.Managers.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.OnDamage();
            }
        }
    }
}
