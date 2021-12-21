using UnityEngine;

namespace CnD.Player.Core
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        private EnemyStats _enemyStats;
        private float _time;

        public void Init()
        {
            _enemyStats = GetComponent<EnemyStats>();
        }
        
        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            _time += Time.deltaTime;
            _enemyStats.sineVer.y = Mathf.Sin(_time * _enemyStats.verticalSpeed) * _enemyStats.verticalAmplitude;
            transform.position = new Vector3(transform.position.x - _enemyStats.movementSpeed * Time.deltaTime,
                transform.position.y + _enemyStats.sineVer.y,
                transform.position.z);
        }

    }
}