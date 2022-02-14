using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Interfaces;
using CnD.Scripts.Utilitaries;
using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class BulletBehaviour : MonoBehaviour
    {
        private SOBulletModel _soBulletModel;
        private bool _isEnemy;

        public void Init(SOBulletModel bulletModel, bool isEnemy)
        {
            _soBulletModel = bulletModel;
            _isEnemy = isEnemy;
        }
        
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        void Update ()
        {
            BulletMovement();
        }

        private void OnTriggerEnter(Collider other)
        {
            IActor actor = other.GetComponent<IActor>();
            actor?.TakeDamage(_soBulletModel.hitPower);
        }

        private void BulletMovement()
        {
            if (!_isEnemy)
            {
                transform.position += transform.right * _soBulletModel.speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * _soBulletModel.speed * Time.deltaTime;
            }
        }
    }
}