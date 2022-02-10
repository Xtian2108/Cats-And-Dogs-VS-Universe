using System;
using System.Collections.Generic;
using CnD.Scripts.Interfaces;
using CnD.Scripts.PowerUps;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerBehaviour : MonoBehaviour, ISpaceShipElement, IActor
    {
        private readonly List<ISpaceShipElement> _spaceShipElements = new List<ISpaceShipElement>();

        public SpaceShipShield spaceShipShield;
        private PlayerStats _playerStats;

        public void Init()
        {
            _playerStats = GetComponent<PlayerStats>();
            spaceShipShield = GetComponent<SpaceShipShield>();
            _spaceShipElements.Add(spaceShipShield);
        }
        

        public void Accept(IVisitor visitor)
        {
            foreach (ISpaceShipElement element in _spaceShipElements)
            {
                element.Accept(visitor);
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public void TakeDamage(int damageReceived)
        {
            if (_playerStats.shield > 0)
            {
                _playerStats.health -= damageReceived;
                if (_playerStats.health <= 0)
                {
                    Die();
                }
            }
            else
            {
                _playerStats.shield -= damageReceived;
            }
        }
    }
}