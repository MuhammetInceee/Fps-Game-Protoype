using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Player
{
    [CreateAssetMenu(menuName = "FPS/Player/PlayerMovementSettings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        [SerializeField] private float playerBaseSpeed;
        public float PlayerBaseSpeed => playerBaseSpeed;

        [SerializeField] private float minDistance;
        public float MinDistance => minDistance;
    }
}
