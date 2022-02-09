using CnD.Scripts.Interfaces;
using CnD.Scripts.PowerUps;
using UnityEngine;

namespace CnD.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp", order = 0)]
    public class PowerUp : ScriptableObject , IVisitor
    {
        public string powerUpName;
        public GameObject powerupPrefab;

        [Tooltip("Heal Shield")]
        public int shieldBoost;

        public void Visit(SpaceShipShield spaceShipShield)
        {
            Debug.Log(spaceShipShield.CurrentShield);
            Debug.Log(spaceShipShield.MaxShield);
            
            var newShieldStrength = spaceShipShield.CurrentShield + shieldBoost;

            spaceShipShield.CurrentShield = (newShieldStrength < spaceShipShield.MaxShield)
                ? spaceShipShield.CurrentShield = newShieldStrength
                : spaceShipShield.CurrentShield = spaceShipShield.MaxShield;

            Debug.LogError(spaceShipShield.CurrentShield);
            Debug.LogError(spaceShipShield.MaxShield);
        }
    }
}