using CnD.ScriptableObjects;
using CnD.Scripts.Utilitaries;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerStats : MonoBehaviour
    {
        [ReadOnly]
        public int movementSpeed;

        [ReadOnly]
        public int health;

        [ReadOnly]
        public int shield;

        [ReadOnly]
        public int maxShield;

        public void SetStats(SOActorModel soActorModel)
        {
            movementSpeed = soActorModel.movementSpeed;
            shield = soActorModel.shield;
            maxShield = soActorModel.maxShield;
            health = soActorModel.health;
        }
    }
}