using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class VerticalBullet : MonoBehaviour
    {
        public void Shoot(Transform transform,int speed ,bool isEnemy)
        {
            if (!isEnemy)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }
        }
    }
}