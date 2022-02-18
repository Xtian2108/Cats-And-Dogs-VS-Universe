using UnityEngine;

namespace CnD.Scripts.Bullet
{
    public class HorizontalBullet : MonoBehaviour
    {
        
        public void Shoot(Transform transform,int speed ,bool isEnemy)
        {
            if (!isEnemy)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }
}