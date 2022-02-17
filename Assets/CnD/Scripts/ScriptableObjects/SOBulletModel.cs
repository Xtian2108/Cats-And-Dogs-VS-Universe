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
        public bool isEnemy;

        [ReadOnly][SerializeField]private BulletMovementType _bulletMovementType;

        public void SetLayer(GameObject gameObject)
        {
            gameObject.layer = LayerMask.NameToLayer(isEnemy ? "Enemy" : "Player");
        }

        public void BulletMovement(Transform transform)
        {
            switch (_bulletMovementType)
            {
                case BulletMovementType.Horizontal:
                    HorizontalShoot(transform);
                    break;
                case BulletMovementType.Vertical:
                    VerticalShoot(transform);
                    break;
            }
            
        }

        private void HorizontalShoot(Transform transform)
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
        
        private void VerticalShoot(Transform transform)
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