using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
using CnD.Scripts.Utilitaries;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CnD.Player.Core
{
    public class ShotBehaviour : MonoBehaviour
    {
        [SerializeField] private SOActorModel _soActorModel;
        private ObjectPool _bulletPool;
        private SOBulletModel _soBulletModel;
        private GameObject _shotPoint;

        public void Init(SOActorModel soActorModel, SOBulletModel soBulletModel)
        {
            _soActorModel = soActorModel;
            _soBulletModel = soBulletModel;
            _shotPoint = GameObject.Find("ShotPoint");
            _bulletPool = new ObjectPool(_soActorModel.bulletGO,15,transform.parent);
        }
        public void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = _bulletPool.GetObject();
                bullet.SetActive(true);
                bullet.transform.position = _shotPoint.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                // GameObject.Instantiate(_soActorModel.bulletGO, _shotPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                bullet.GetComponent<BulletBehaviour>().Init(_soBulletModel,_bulletPool);
                bullet.transform.SetParent(transform.parent);
                bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}