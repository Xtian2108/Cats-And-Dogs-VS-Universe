using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Utilitaries;
using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class BulletBehaviour : MonoBehaviour
    {
        private SOBulletModel _soBulletModel;
        private ObjectPool _bulletPool;

        public void Init(SOBulletModel bulletModel, ObjectPool bulletPool)
        {
            _soBulletModel = bulletModel;
            _bulletPool = bulletPool;
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        void Update () 
        {
            transform.position += new Vector3(_soBulletModel.speed,0,0)*Time.deltaTime;	
        }

    }
}