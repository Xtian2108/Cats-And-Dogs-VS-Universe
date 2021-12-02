using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class BulletStats : MonoBehaviour
    {
        internal int hitPower;
        internal int health;
        internal int travelSpeed;

        public void SetBulletStats(SOBulletModel soBulletModel)
        {
            hitPower = soBulletModel.hitPower;
            health = soBulletModel.health;
            travelSpeed = soBulletModel.speed;
        }
    }
}