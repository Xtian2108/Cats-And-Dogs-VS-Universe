using System;
using System.Collections.Generic;
using CnD.Player.Bullet;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
using CnD.Scripts.Interfaces;
using CnD.Scripts.PowerUps;
using UnityEngine;

namespace CnD.Scripts.Controller
{
    public class PlayerSpawnerController : MonoBehaviour
    {
        public SOActorModel soActorModel;
        [SerializeField]private Transform _spawnPoint;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            CreatePlayer();
        }

        private GameObject CreatePlayer()
        {
            GameObject playerShipModel = Instantiate(soActorModel.shipGO);
            playerShipModel.AddComponent<PlayerMovementBehaviour>();
            playerShipModel.AddComponent<PlayerStats>();
            playerShipModel.GetComponent<PlayerStats>().SetStats(soActorModel);
            playerShipModel.AddComponent<SpaceShipShield>();
            playerShipModel.GetComponent<SpaceShipShield>().Init(soActorModel);
            playerShipModel.AddComponent<PlayerBehaviour>();
            playerShipModel.GetComponent<PlayerBehaviour>().Init();
            SetPlayerInWorld(playerShipModel);
            return playerShipModel;
        }

        private void SetPlayerInWorld(GameObject playerShip)
        {
            playerShip.transform.position = _spawnPoint.position;
            playerShip.transform.rotation = Quaternion.Euler(0, 90, 0);
            playerShip.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            playerShip.transform.SetParent(transform);
        }
    }
}