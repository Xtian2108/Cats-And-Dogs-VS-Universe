using System;
using System.Collections.Generic;
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
        [SerializeField]private int amountShotPoint = 1;
        public List<SOBulletModel> soBulletModel = new List<SOBulletModel>();
        [SerializeField]private GameObject[] shotPoint;
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
                for (int i = 0; i < amountShotPoint; i++)
                {
                    GameObject bullet = _bulletPoolContainer.bulletPool.GetObject();
                    SetTransformBullet(bullet,soBulletModel[i],shotPoint[i].transform.position);
                }
                
            }
        }

        private void EnemyShoot()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            GameObject bullet = _bulletPoolContainer.bulletPool.GetObject();
            SetTransformBullet(bullet,soBulletModel[0],shotPoint[0].transform.position);
        }

        private void SetTransformBullet(GameObject bullet, SOBulletModel SOBulletModel, Vector3 shotPosition)
        {
            bullet.SetActive(true);
            bullet.transform.position = shotPosition;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bullet.GetComponent<BulletBehaviour>().Init(SOBulletModel);
            bullet.transform.SetParent(transform.parent);
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}