using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace FPS.Managers.Gun
{
    [CreateAssetMenu(menuName = "FPS/Managers/GunManagerSettings")]
    public class GunManagerSO : ScriptableObject
    {
        [SerializeField] private float gunRotateSpeed;
        public float GunRotateSpeed => gunRotateSpeed;

        [SerializeField] private Ease gunRotateEase;
        public Ease GunRotateEase => gunRotateEase;

        [SerializeField] private Ease shootEase;
        public Ease ShootEase => shootEase;
    }
}
