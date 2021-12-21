using System;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
using UnityEngine;

namespace CnD.Scripts.Controller
{
    public class PlayerSpawnerController : MonoBehaviour
    {
        [SerializeField]private SOActorModel _soActorModel;
        [SerializeField]private SOBulletModel _soBulletModel;

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
            GameObject _playerShipModel = Instantiate(_soActorModel.shipGO);
            _playerShipModel.AddComponent<PlayerMovementBehaviour>();
            _playerShipModel.AddComponent<ShotBehaviour>();
            _playerShipModel.GetComponent<ShotBehaviour>().Init(_soActorModel,_soBulletModel);
            _playerShipModel.AddComponent<PlayerStats>();
            _playerShipModel.GetComponent<PlayerStats>().SetStats(_soActorModel);
            SetPlayerInWorld(_playerShipModel);
            return _playerShipModel;
        }


        private void SetPlayerInWorld(GameObject playerShip)
        {
            playerShip.transform.position = new Vector3(-7, 0, 40);
            playerShip.transform.rotation = Quaternion.Euler(0, 90, 0);
            playerShip.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            playerShip.transform.SetParent(transform);
        }
    }
}