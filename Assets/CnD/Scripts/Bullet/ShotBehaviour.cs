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
        [SerializeField] private SOActorModel _soActorModel;
        private ObjectPool _bulletPool;
        private SOBulletModel _soBulletModel;
        [HideInInspector]public GameObject shotPoint;

        public void Init(SOActorModel soActorModel, SOBulletModel soBulletModel)
        {
            _soActorModel = soActorModel;
            _soBulletModel = soBulletModel;
            _bulletPool = new ObjectPool(_soActorModel.bulletGO,60,transform.parent);
            if (_soActorModel.isEnemy)
            {
                Debug.Log(gameObject.name);
                InvokeRepeating("EnemyShoot",2,2 );
            }
        }
        public void Update()
        {
            PlayerShoot();
        }

        private void PlayerShoot()
        {
            if (_soActorModel.isEnemy)
            {
                return;
            }
            
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = _bulletPool.GetObject();
                bullet.SetActive(true);
                bullet.transform.position = shotPoint.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                bullet.GetComponent<BulletBehaviour>().Init(_soBulletModel,_soActorModel.isEnemy);
                bullet.transform.SetParent(transform.parent);
                bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }

        private void EnemyShoot()
        {
            GameObject bullet = _bulletPool.GetObject();
            bullet.SetActive(true);
            bullet.transform.position = shotPoint.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bullet.GetComponent<BulletBehaviour>().Init(_soBulletModel,_soActorModel.isEnemy);
            bullet.transform.SetParent(transform.parent);
            bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}