using System;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace CnD.Scripts.PowerUps
{
    public class PowerUpItem : MonoBehaviour
    {

        public SOPowerUp soPowerUp;

        private void OnTriggerEnter(Collider other)
        {
            PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
            if (playerBehaviour)
            {
                playerBehaviour.Accept(soPowerUp);
                Destroy(gameObject);
            }
        }
    }
}