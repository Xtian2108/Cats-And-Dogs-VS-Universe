using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Bullet Model", menuName = "Create Bullet")]
    public class SOBulletModel : ScriptableObject
    {
        public int speed;
        public int health;
        public int hitPower;
    }
}