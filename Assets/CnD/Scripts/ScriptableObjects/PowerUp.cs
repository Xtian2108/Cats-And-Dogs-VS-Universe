using CnD.Scripts.Interfaces;
using CnD.Scripts.PowerUps;
using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class PowerUp : ScriptableObject , IVisitor
    {
        public string powerUpName;
        public GameObject powerupPrefab;
        public string powerUpDescription;

        [Tooltip("Heal Shield")]
        public int shieldBoost;
        
        [Range(0.0f,50f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;

        public void Visit(SpaceShipShield spaceShipShield)
        {
            var newShieldStrength = spaceShipShield.CurrentShield + shieldBoost;

            spaceShipShield.CurrentShield = (newShieldStrength < spaceShipShield.MaxShield)
                ? spaceShipShield.CurrentShield = newShieldStrength
                : spaceShipShield.CurrentShield = spaceShipShield.MaxShield;
        }
    }
}