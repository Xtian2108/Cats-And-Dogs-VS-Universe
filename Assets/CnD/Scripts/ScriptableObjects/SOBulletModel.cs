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
        
    }
}