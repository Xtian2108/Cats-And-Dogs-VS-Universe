using System;
using System.Collections;
using CnD.Player.Bullet;
using CnD.Player.Core;
using CnD.ScriptableObjects;
using CnD.Scripts.Utilitaries;
using UnityEngine;

namespace CnD.Player.Controller
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] private SOActorModel _soActorModel;
        [SerializeField] private SOBulletModel _soBulletModel;
        [SerializeField][Range(0,10)]private int _quantity;
        [SerializeField][Range(0.1f,2f)]private float _spawnRate;
        private ObjectPool _enemiesPool;
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _enemiesPool = new ObjectPool(_soActorModel.shipGO,_quantity,transform.parent);
            StartCoroutine(SpawnEnemies(_quantity,_spawnRate));
        }
        
        private IEnumerator SpawnEnemies(int quantity, float spawnRate)
        {
            for (int i = 0; i < quantity; i++)
            {
                GameObject enemy = CreateEnemy();
                enemy.transform.rotation = Quaternion.Euler(0, -90, 0);
                enemy.gameObject.transform.SetParent(transform);
                enemy.transform.position = transform.position;
                yield return new WaitForSeconds(spawnRate);
            }
            yield return null;
        }

        private GameObject CreateEnemy()
        {
            GameObject enemy = _enemiesPool.GetObject();
            enemy.SetActive(true);
            enemy.AddComponent<EnemyStats>();
            enemy.GetComponent<EnemyStats>().SetStats(_soActorModel);
            if (_soActorModel.bulletGO != null)
            {
                enemy.AddComponent<ShotBehaviour>();
                enemy.GetComponent<ShotBehaviour>().Init(_soActorModel,_soBulletModel);
                enemy.GetComponent<ShotBehaviour>().shotPoint = enemy.transform.Find("ShotPoint").gameObject;
            }
            enemy.AddComponent<EnemyMovementBehaviour>();
            enemy.GetComponent<EnemyMovementBehaviour>().Init();
            enemy.name = _soActorModel.name;
            return enemy;
        }
        
        #region EDITOR FUNCTIONS
        private void OnDrawGizmos()
        {
            // Draw a semitransparent blue cube at the transforms position
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        }
        #endregion
    }
}