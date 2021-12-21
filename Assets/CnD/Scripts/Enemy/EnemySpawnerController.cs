using System;
using System.Collections;
using CnD.ScriptableObjects;
using UnityEngine;

namespace CnD.Player.Core
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] private SOActorModel _soActorModel;
        [SerializeField][Range(0,10)]private int _quantity;
        [SerializeField][Range(0.1f,2f)]private float _spawnRate;
        private GameObject _playerShipModel;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
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
            GameObject enemy = Instantiate(_soActorModel.shipGO);
            enemy.AddComponent<EnemyStats>();
            enemy.GetComponent<EnemyStats>().SetStats(_soActorModel);
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