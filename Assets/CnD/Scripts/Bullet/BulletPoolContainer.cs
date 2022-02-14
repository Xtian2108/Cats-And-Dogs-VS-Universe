using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Utilitaries;
using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class BulletPoolContainer : MonoBehaviour
    {
        public ObjectPool bulletPool;
        public SOBulletModel soBulletModel;
        
        public void Awake()
        {
            bulletPool = new ObjectPool(soBulletModel.bulletGO, 60, transform.parent);
        }
    }
}