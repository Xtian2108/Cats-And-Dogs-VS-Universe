using System;
using CnD.Scripts.Bullet;
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
        public bool _isEnemy;
        
        public void BulletMovement(Transform transform)
        {
            if (!_isEnemy)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }
}