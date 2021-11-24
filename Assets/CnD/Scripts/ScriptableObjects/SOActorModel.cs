using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Create Actor Model", menuName = "Create Actor")]
    public class SOActorModel : ScriptableObject
    {
        public int movementSpeed;
        public enum ControllerType
        {
            KEYBOARD,
            JOYSTICK
        };
    }
}