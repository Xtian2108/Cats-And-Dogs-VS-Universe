using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerStats : MonoBehaviour
    {
        internal int movementSpeed;
        internal int shield;
        internal int maxShield;
        public void SetStats(SOActorModel soActorModel)
        {
            movementSpeed = soActorModel.movementSpeed;
            shield = soActorModel.shield;
            maxShield = soActorModel.maxShield;
        }
    }
}