using System;
using System.Collections.Generic;
using CnD.Scripts.Interfaces;
using CnD.Scripts.PowerUps;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerBehaviour : MonoBehaviour, ISpaceShipElement
    {
        private readonly List<ISpaceShipElement> _spaceShipElements = new List<ISpaceShipElement>();

        public SpaceShipShield spaceShipShield;

        public void Init()
        {
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
    }
}