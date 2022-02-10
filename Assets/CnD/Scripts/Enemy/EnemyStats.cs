using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Player.Core
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] internal float verticalSpeed = 2;
        [SerializeField] internal float verticalAmplitude = 1;
        [SerializeField] internal float movementSpeed = 1;
        [SerializeField] internal Vector3 sineVer;
        internal int health;

        public void SetStats(SOActorModel soActorModel)
        {
            movementSpeed = soActorModel.movementSpeed;
            verticalSpeed = soActorModel.verticalSpeed;
            verticalAmplitude = soActorModel.verticalAmplitude;
            health = soActorModel.health;
        }
    }
}