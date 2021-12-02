using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CnD.Player.Core
{
    public class ShotBehaviour : MonoBehaviour
    {
        [SerializeField] private SOActorModel _soActorModel;
        private SOBulletModel _soBulletModel;
        private GameObject _shotPoint;

        public void Init(SOActorModel soActorModel, SOBulletModel soBulletModel)
        {
            _soActorModel = soActorModel;
            _soBulletModel = soBulletModel;
            _shotPoint = GameObject.Find("ShotPoint");
        }
        public void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet =
                    GameObject.Instantiate(_soActorModel.bulletGO, _shotPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                bullet.GetComponent<BulletBehaviour>().Init(_soBulletModel);
                bullet.transform.SetParent(transform.parent);
                bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}