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
        private BulletMovementType _bulletMovementType;
        private VerticalBullet _verticalBullet;
        private HorizontalBullet _horizontalBullet;
        
        private void Start()
        {
            _verticalBullet = gameObject.AddComponent<VerticalBullet>();
            _horizontalBullet = gameObject.AddComponent<HorizontalBullet>();
        }

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

        void FixedUpdate()
        {
            BulletMovement();
        }

        private void BulletMovement()
        {
            switch (_bulletMovementType)
            {
                case BulletMovementType.Horizontal:
                    _horizontalBullet.Shoot(transform,_soBulletModel.speed,isEnemy);
                    break;
                case BulletMovementType.Vertical:
                    _verticalBullet.Shoot(transform,_soBulletModel.speed,isEnemy);
                    break;
            }
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