using FPS.Systems.TargetFinder;
using Sirenix.OdinInspector;
using FPS.Managers.Bullet;
using System.Collections;
using FPS.Managers.Pool;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace FPS.Managers.Gun
{
    public class GunManager : MonoBehaviour
    {
        private float _lastShootTime = 0;
        private float _tempEnemyHealth;

        [SerializeField] private float fireRate; // Incremental olarak baglanacak //TODO

        [FoldoutGroup("Animations")] [SerializeField] private Animator animator;
        
        [FoldoutGroup("References")] [SerializeField] private GunManagerSO gunManagerSettings;
        [FoldoutGroup("References")] [SerializeField] private BulletSettings bulletSettings;
        [FoldoutGroup("References")] [SerializeField] private TargetFinder targetFinder;
        [FoldoutGroup("References")] [SerializeField] private BulletPoolingManager bulletPoolManger;
        
        [FoldoutGroup("Gun Part")] [SerializeField] private GameObject gun;
        [FoldoutGroup("Gun Part")] [SerializeField] private GameObject magazine;
        [FoldoutGroup("Gun Part")] [SerializeField] private Transform firePos;


        private EnemyTest TargetEnemy => targetFinder.target;

        private void Awake()
        { 
            TurnTarget();
        }

        private void Update()
        {
            ShootSystem();
        }

        private void ShootSystem()
        {
            Shoot();
            
            if ((_tempEnemyHealth + bulletSettings.bulletDamage) <= bulletSettings.bulletDamage)
            {
                targetFinder.enemyLists[0].waveEnemies.Remove(TargetEnemy.gameObject);
                
                if (targetFinder.enemyLists[0].waveEnemies.Count == 0)
                {
                    targetFinder.enemyLists.Remove(targetFinder.enemyLists[0]);
                }
                TurnTarget();
            }
        }
        
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void TurnTarget()
        {
            targetFinder.target = null;
            targetFinder.CalculateTarget();
            _tempEnemyHealth = TargetEnemy.health;
            gun.transform.DOLookAt(TargetEnemy.transform.position, gunManagerSettings.GunRotateSpeed * 1 / fireRate)
                .SetEase(gunManagerSettings.GunRotateEase)
                .SetSpeedBased();
        }

        private void Shoot()
        {
            if (Time.time > _lastShootTime + fireRate)
            {
                _lastShootTime = Time.time;
                if(TargetEnemy == null) return;
                
                StartCoroutine(Recoil());
                GameObject bullet = GetReadyBullet();
                
                _tempEnemyHealth -= bulletSettings.bulletDamage;
                bullet.transform.DOMove(TargetEnemy.transform.position, bulletSettings.BulletSpeed)
                    .SetSpeedBased()
                    .SetEase(gunManagerSettings.ShootEase)
                    .OnComplete(() =>
                    {
                        StartCoroutine(SetBackPoolBullet(bullet));
                    });
                magazine.transform.DORotate(new Vector3(0, 0, -60), 0.2f).SetRelative();
            }
        }

        private IEnumerator Recoil()
        {
            animator.Play("RecoilAnim");
            yield return new WaitForSeconds(0.1f);
            animator.Play("New State");
        }

        private GameObject GetReadyBullet()
        {
            GameObject bullet = bulletPoolManger.bulletList.FirstOrDefault(m => !m.activeInHierarchy);
            bullet!.transform.position = firePos.position;
            bullet!.SetActive(true);

            return bullet;
        }

        private IEnumerator SetBackPoolBullet(GameObject bullet)
        {
            yield return null;
            bullet.transform.position = Vector3.zero;
            bullet.SetActive(false);
        }

    }
}
