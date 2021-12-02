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
        private GameObject _playerShipModel;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            _playerShipModel = Instantiate(_soActorModel.shipGO);
            _playerShipModel.AddComponent<PlayerMovementBehaviour>();
            _playerShipModel.AddComponent<ShotBehaviour>();
            _playerShipModel.GetComponent<ShotBehaviour>().Init(_soActorModel,_soBulletModel);
            _playerShipModel.AddComponent<PlayerStats>();
            _playerShipModel.GetComponent<PlayerStats>().SetStats(_soActorModel);
            SetPlayerInWorld();
        }

        private void SetPlayerInWorld()
        {
            _playerShipModel.transform.position = new Vector3(-7, 0, 40);
            _playerShipModel.transform.rotation = Quaternion.Euler(0, 90, 0);
            _playerShipModel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            _playerShipModel.transform.SetParent(transform);
        }
    }
}