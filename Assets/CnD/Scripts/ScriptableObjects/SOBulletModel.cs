using System;
using CnD.Scripts.Bullet;
using CnD.Scripts.Utilitaries;
using UnityEngine;
using UnityEngine.Serialization;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Bullet Model", menuName = "Create Bullet")]
    public class SOBulletModel : ScriptableObject
    {
        [FormerlySerializedAs("bulletTypes")]
        public GameObject bulletGO;

        public int currentType;
        public int speed;
        public int health;
        public int hitPower;

        [FormerlySerializedAs("_isEnemy")]
        [ReadOnly]
        [SerializeField]
        private BulletMovementType _bulletMovementType;

        public void BulletMovement(Transform transform, bool isEnemy)
        {
            switch (_bulletMovementType)
            {
                case BulletMovementType.Horizontal:
                    HorizontalShoot(transform,isEnemy);
                    break;
                case BulletMovementType.Vertical:
                    VerticalShoot(transform, isEnemy);
                    break;
            }
        }

        private void HorizontalShoot(Transform transform, bool isEnemy)
        {
            if (!isEnemy)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }

        private void VerticalShoot(Transform transform, bool isEnemy)
        {
            if (!isEnemy)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }
        }
    }
}