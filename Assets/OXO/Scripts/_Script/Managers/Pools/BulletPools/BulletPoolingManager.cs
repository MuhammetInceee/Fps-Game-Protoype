using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Managers.Pool
{
    public class BulletPoolingManager : MonoBehaviour
    {
        private Transform _tr;

        [SerializeField] private int poolSize;
        [SerializeField] private GameObject bulletPrefab;

        public List<GameObject> bulletList;


        private void Awake()
        {
            GetReferences();
            CreatePool();
        }

        private void CreatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, _tr.position, Quaternion.identity, _tr);
                bulletList.Add(bullet);
                bullet.SetActive(false);
            }
        }

        private void GetReferences()
        {
            _tr = GetComponent<Transform>();
        }
    }
}