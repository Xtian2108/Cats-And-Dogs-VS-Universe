using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Actor Model", menuName = "Create Actor")]
    public class SOActorModel : ScriptableObject
    {
        public int movementSpeed;
        public GameObject shipGO;
        public GameObject bulletGO;
        public enum ControllerType
        {
            KEYBOARD,
            JOYSTICK
        };

    }
}