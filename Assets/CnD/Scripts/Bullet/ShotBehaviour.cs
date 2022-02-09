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
                Debug.Log(gameObject.name);
                InvokeRepeating("EnemyShoot", 2, 2);
            }
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
                SetTransformBullet(bullet);
            }
        }

        private void EnemyShoot()
        {
            GameObject bullet = _bulletPoolContainer.bulletPool.GetObject();
            SetTransformBullet(bullet);
        }

        private void SetTransformBullet(GameObject bullet)
        {
            bullet.SetActive(true);
            bullet.transform.position = shotPoint.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bullet.GetComponent<BulletBehaviour>().Init(soBulletModel, soActorModel.isEnemy);
            bullet.transform.SetParent(transform.parent);
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}