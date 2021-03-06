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
        [SerializeField] [Range(0, 10)] private int _quantity;
        [SerializeField] [Range(0.1f, 2f)] private float _spawnRate;
        private ObjectPool _enemiesPool;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _enemiesPool = new ObjectPool(_soActorModel.ActorGO, _quantity, transform.parent);
            StartCoroutine(SpawnEnemies(_quantity, _spawnRate));

        }
        private IEnumerator SpawnEnemies(int quantity, float spawnRate)
        {
            for (int i = 0; i < quantity; i++)
            {
                CreateEnemy();
                yield return new WaitForSeconds(spawnRate);
            }

            yield return null;
        }

        private GameObject CreateEnemy()
        {
            GameObject enemy = _enemiesPool.GetObject();
            enemy.SetActive(true);
            enemy.transform.rotation = Quaternion.Euler(0, -90, 0);
            enemy.gameObject.transform.SetParent(transform);
            enemy.transform.position = transform.position;
            if (enemy.GetComponent<EnemyStats>())
            {
                return enemy;
            }
            enemy.AddComponent<EnemyStats>();
            enemy.GetComponent<EnemyStats>().SetStats(_soActorModel);
            enemy.AddComponent<EnemyMovementBehaviour>();
            enemy.GetComponent<EnemyMovementBehaviour>().Init();
            enemy.AddComponent<EnemyBehaviour>();
            enemy.GetComponent<EnemyBehaviour>().Init();
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