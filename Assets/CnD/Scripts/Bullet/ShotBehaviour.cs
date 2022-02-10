using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Bullet;
using CnD.Scripts.Utilitaries;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CnD.Player.Bullet
{
    public class ShotBehaviour : MonoBehaviour
    {
        public SOActorModel soActorModel;
        public SOBulletModel soBulletModel;
        public GameObject shotPoint;
        public GameObject shotPoint2;
        public GameObject shotPoint3;
        private BulletPoolContainer _bulletPoolContainer;
        public void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            if (_bulletPoolContainer == null)
            {
                _bulletPoolContainer = FindObjectOfType<BulletPoolContainer>();
            }
            if (soActorModel.isEnemy)
            {
                if (!CanShoot()) return;
                InvokeRepeating("EnemyShoot", 5, 5);
            }
        }

        private bool CanShoot()
        {
            int random = UnityEngine.Random.Range(0,2);
            return random == 0;
        }
        

        public void Update()
        {
            PlayerShoot();
        }

        private void PlayerShoot()
        {
            if (soActorModel.isEnemy)
            {
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = _bulletPoolContainer.bulletPool.GetObject();
                SetTransformBullet(bullet,shotPoint.transform.position);
                GameObject bullet2 = _bulletPoolContainer.bulletPool.GetObject();
                SetTransformBullet(bullet2,shotPoint2.transform.position);
                GameObject bullet3 = _bulletPoolContainer.bulletPool.GetObject();
                SetTransformBullet(bullet3,shotPoint3.transform.position);
            }
        }

        private void EnemyShoot()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            GameObject bullet = _bulletPoolContainer.bulletPool.GetObject();
            SetTransformBullet(bullet,shotPoint.transform.position);
        }

        private void SetTransformBullet(GameObject bullet, Vector3 shotPosition)
        {
            bullet.SetActive(true);
            bullet.transform.position = shotPosition;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bullet.GetComponent<BulletMovementBehaviour>().Init(soBulletModel, soActorModel.isEnemy);
            bullet.transform.SetParent(transform.parent);
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}