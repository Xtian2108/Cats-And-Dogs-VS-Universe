using System;
using CnD.ScriptableObjects;
using CnD.Scripts.Environment;
using UnityEngine;

namespace CnD.Player.Core
{
    public class PlayerMovementController : MonoBehaviour
    {
        private int movementSpeed;
        private EnvironmentBoundaries _environmentBoundaries;
        [SerializeField]private SOActorModel _soActorModel;
        
        public int MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _environmentBoundaries = FindObjectOfType<EnvironmentBoundaries>();
            if (_environmentBoundaries)
            {
                _environmentBoundaries.Init();
            }
            SetStats(_soActorModel);
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void SetStats(SOActorModel soActorModel)
        {
            movementSpeed = soActorModel.movementSpeed;
        }

        

        private void Movement()
        {
            float moveX = 0f;
            float moveY = 0f;
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (transform.localPosition.x <
                    (_environmentBoundaries.boundariesPoints[1].transform.localPosition.x - _environmentBoundaries.boundariesPoints[1].transform.localPosition.x / 30f))
                {
                    moveX += 1f;
                }
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (transform.localPosition.x >
                    (_environmentBoundaries.boundariesPoints[0].transform.localPosition.x + _environmentBoundaries.boundariesPoints[0].transform.localPosition.x / 30f))
                {
                    moveX -= 1f;
                }
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (transform.localPosition.y > (_environmentBoundaries.boundariesPoints[1].transform.localPosition.y -
                                                 _environmentBoundaries.boundariesPoints[1].transform.localPosition.y / 3f))
                {
                    moveY -= 1f;
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (transform.localPosition.y < (_environmentBoundaries.boundariesPoints[0].transform.localPosition.y -
                                                 _environmentBoundaries.boundariesPoints[0].transform.localPosition.y / 5))
                {
                    moveY += 1f;
                }
            }
            
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            transform.position += moveDir * movementSpeed * Time.deltaTime;
        }
        
    }
}

