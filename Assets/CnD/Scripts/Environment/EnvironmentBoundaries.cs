using UnityEngine;

namespace CnD.Scripts.Environment
{
    public class EnvironmentBoundaries : MonoBehaviour
    {
        [HideInInspector]public GameObject[] boundariesPoints = new GameObject[2];
        [SerializeField] private float cameraTopOffset;
        [SerializeField] private float cameraBottomOffset;
        [SerializeField] private float cameraLeftOffset;
        [SerializeField] private float cameraRightOffset;
        public void Init()
        {
            CalculateBoundaries();
        }
        private void CalculateBoundaries()
        {
            
            #region Setting Boundaries
            float leftBound = OrthographicBounds(Camera.main).min.x;
            float rightBound = OrthographicBounds(Camera.main).max.x;
            float bottomBound = OrthographicBounds(Camera.main).min.y;
            float topBound = OrthographicBounds(Camera.main).max.y;
            #endregion
            
            
            boundariesPoints[0] = new GameObject("p1");
            boundariesPoints[1] = new GameObject("p2");
            boundariesPoints[0].transform.SetParent(transform);
            boundariesPoints[1].transform.SetParent(transform);
            Vector3 v1 = new Vector3(leftBound + cameraLeftOffset, topBound + cameraTopOffset, 0);
            Vector3 v2 = new Vector3(rightBound - cameraRightOffset, bottomBound - cameraBottomOffset, 0);
            boundariesPoints[0].transform.position = v1;
            boundariesPoints[1].transform.position = v2;
            
        }
        
        public Bounds OrthographicBounds(Camera camera)
        {
            float cameraHeight = camera.orthographicSize * 2;
            Bounds bounds = new Bounds(
                camera.transform.position,
                new Vector3(cameraHeight * camera.aspect, cameraHeight, 0));
            return bounds;
        }
    }
}