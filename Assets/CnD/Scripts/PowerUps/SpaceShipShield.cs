using CnD.Scripts.Interfaces;
using UnityEngine;

namespace CnD.Scripts.PowerUps
{
    public class SpaceShipShield : MonoBehaviour, ISpaceShipElement
    {
        public int currentShieldHealth;
        public int maxShield = 5;

        public void Awake()
        {
            ResetShieldStrength();
        }
        
        public float TakeDamage(int damage)
        {
            currentShieldHealth -= damage;
            return currentShieldHealth;
        }

        public void ResetShieldStrength()
        {
            currentShieldHealth = maxShield;
        }
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}