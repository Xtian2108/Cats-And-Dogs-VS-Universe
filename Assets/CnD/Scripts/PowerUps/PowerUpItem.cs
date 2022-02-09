using System;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Scripts.PowerUps
{
    public class PowerUpItem : MonoBehaviour
    {
        public PowerUp powerUpSO;

        private void OnTriggerEnter(Collider other)
        {
            PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
            if (playerBehaviour)
            {
                playerBehaviour.Accept(powerUpSO);
                Destroy(gameObject);
            }
        }
    }
}