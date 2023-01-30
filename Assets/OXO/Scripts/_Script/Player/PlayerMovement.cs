using System;
using System.Collections;
using System.Collections.Generic;
using FPS.Systems.TargetFinder;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rb;
        private float _movementSpeed;

        [FoldoutGroup("References")] [SerializeField] private PlayerMovementSettings playerMovementSettings;
        [FoldoutGroup("References")] [SerializeField] private TargetFinder targetFinder;

        private void Awake()
        {
            GetReference();
            InitVariables();
        }

        private void Update()
        {
            VerticalMovement();
        }

        private void VerticalMovement()
        {
            _rb.MovePosition(_rb.position + Vector3.forward * CalculateSpeed());
        }

        private float CalculateSpeed()
        {
            _movementSpeed = playerMovementSettings.PlayerBaseSpeed * 
                             (Vector3.Distance(transform.position, targetFinder.target.transform.position) - playerMovementSettings.MinDistance);
            return _movementSpeed;
        }

        private void GetReference()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void InitVariables()
        {

        }
    }
}
