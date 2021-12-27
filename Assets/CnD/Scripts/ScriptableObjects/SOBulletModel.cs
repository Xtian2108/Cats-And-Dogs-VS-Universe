using System.Collections.Generic;
using CnD.Scripts.Bullet;
using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Bullet Model", menuName = "Create Bullet")]
    public class SOBulletModel : ScriptableObject
    {
        public List<GameObject> bulletTypes = new List<GameObject>();
        public int currentType;
        public int speed;
        public int health;
        public int hitPower;
    }
}