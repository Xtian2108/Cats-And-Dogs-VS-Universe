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
        private bool isEnemy;
        
        public void Init(SOBulletModel bulletModel, SOActorModel soActorModel)
        {
            _soBulletModel = bulletModel;
            isEnemy = soActorModel.isEnemy;
            SetLayer();
        }

        private void SetLayer()
        {
            gameObject.layer = LayerMask.NameToLayer(isEnemy ? "Enemy" : "Player");
        }
        
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        void Update ()
        {
            _soBulletModel.BulletMovement(transform,isEnemy);
        }

        private void OnTriggerEnter(Collider other)
        {
            IActor actor = other.GetComponent<IActor>();
            if (actor != null)
            {
                actor?.TakeDamage(_soBulletModel.hitPower);
                gameObject.SetActive(false);
            }
            
        }
    }
}