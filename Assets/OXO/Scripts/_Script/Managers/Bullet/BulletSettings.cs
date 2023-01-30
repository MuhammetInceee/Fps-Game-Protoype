using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Managers.Bullet
{
    [CreateAssetMenu(menuName = "FPS/Managers/BulletSettings")]
    public class BulletSettings : ScriptableObject
    {
        [SerializeField] private float bulletSpeed;
        public float BulletSpeed => bulletSpeed;


        public float bulletDamage; // Incremental olarak baglanacak  //TODO
    }
}
