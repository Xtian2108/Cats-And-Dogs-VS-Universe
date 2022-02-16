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
        
        public void Init(SOBulletModel bulletModel)
        {
            _soBulletModel = bulletModel;
        }
        
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        void Update ()
        {
            _soBulletModel.BulletMovement(transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            IActor actor = other.GetComponent<IActor>();
            if (actor != null)
            {
                actor?.TakeDamage(_soBulletModel.hitPower);
                Destroy(other.gameObject);
            }
            
        }
    }
}