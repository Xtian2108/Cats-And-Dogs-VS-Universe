using CnD.ScriptableObjects;
using CnD.Scripts.Interfaces;
using UnityEngine;

namespace CnD.Scripts.PowerUps
{
    public class SpaceShipShield : MonoBehaviour, ISpaceShipElement
    {
        private SOActorModel _actorModel;
        public int CurrentShield
        {
            get => _actorModel.shield;
            set => _actorModel.shield = value;
        }

        public int MaxShield => _actorModel.maxShield;
        
        public void Init(SOActorModel actorModel)
        {
            _actorModel = actorModel;
        }
        
        public float TakeDamage(int damage)
        {
            CurrentShield -= 1;
            return CurrentShield;
        }
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}