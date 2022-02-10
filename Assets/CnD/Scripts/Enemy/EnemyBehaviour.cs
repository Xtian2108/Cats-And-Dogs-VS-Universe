using System;
using CnD.Scripts.Interfaces;
using UnityEngine;

namespace CnD.Player.Core
{
    public class EnemyBehaviour : MonoBehaviour, IActor
    {
        private EnemyStats _enemyStats;
        
        public void Init()
        {
            _enemyStats = GetComponent<EnemyStats>();
        }
        

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public void TakeDamage(int damageReceived)
        {
            _enemyStats.health -= damageReceived;
            if (_enemyStats.health <= 0)
            {
                Die();
            }
        }
    }
}