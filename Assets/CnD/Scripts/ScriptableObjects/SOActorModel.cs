using UnityEngine;
using UnityEngine.Serialization;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Actor Model", menuName = "Create Actor")]
    public class SOActorModel : ScriptableObject
    {
        public int health;
        public int movementSpeed;
        public int shield;
        public int maxShield = 5;
        public string name;
        public float fireRate;
        [FormerlySerializedAs("shipGO")]
        public GameObject ActorGO;
        public bool isEnemy;

        [Header("Enemy Stats")] 
        [Range(0.1f,1f)]public float verticalSpeed = 1;
        [Range(0.02f,0.05f)]public float verticalAmplitude = 0.05f;

    }
}