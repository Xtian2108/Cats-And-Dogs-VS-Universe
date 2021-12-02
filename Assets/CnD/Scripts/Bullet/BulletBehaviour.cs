using System;
using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class BulletBehaviour : MonoBehaviour
    {
        private SOBulletModel _soBulletModel;

        public void Init(SOBulletModel bulletModel)
        {
            _soBulletModel = bulletModel;
        }
        void Update () 
        {
            transform.position += new Vector3(_soBulletModel.speed,0,0)*Time.deltaTime;	
        }

    }
}