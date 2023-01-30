using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Systems.TargetFinder
{
    public class TargetFinder : MonoBehaviour
    {
        public List<EnemyList> enemyLists;
        
        public EnemyTest target;
        
        public EnemyTest GetClosestEnemy()
        {
            EnemyTest bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
            
            foreach (GameObject potentialTarget in enemyLists[0].waveEnemies)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget.GetComponent<EnemyTest>();
                }
            }

            return bestTarget;
        }

        public void CalculateTarget()
        {
            target = GetClosestEnemy();
        }
    }

    [System.Serializable]
    public class EnemyList
    {
        public List<GameObject> waveEnemies;
    }
}
