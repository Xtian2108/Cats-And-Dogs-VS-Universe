using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerStats : MonoBehaviour
    {
        internal int movementSpeed;
        public void SetStats(SOActorModel soActorModel)
        {
            movementSpeed = soActorModel.movementSpeed;
        }
    }
}