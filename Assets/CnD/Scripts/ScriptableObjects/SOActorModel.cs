using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Actor Model", menuName = "Create Actor")]
    public class SOActorModel : ScriptableObject
    {
        public int movementSpeed;
        public string name;
        public GameObject shipGO;
        public bool isEnemy;

        [Header("Enemy Stats")] 
        [Range(0.1f,1f)]public float verticalSpeed = 1;
        [Range(0.02f,0.05f)]public float verticalAmplitude = 0.05f;
        public enum ControllerType
        {
            KEYBOARD,
            JOYSTICK
        };

    }
}