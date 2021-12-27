using System;
using CnD.Player.Bullet;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
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
            GameObject _playerShipModel = Instantiate(soActorModel.shipGO);
            _playerShipModel.AddComponent<PlayerMovementBehaviour>();
            _playerShipModel.AddComponent<PlayerStats>();
            _playerShipModel.GetComponent<PlayerStats>().SetStats(soActorModel);
            SetPlayerInWorld(_playerShipModel);
            return _playerShipModel;
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