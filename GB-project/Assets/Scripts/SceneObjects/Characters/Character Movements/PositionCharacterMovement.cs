using System;
using UnityEngine;

namespace GBproject
{    
    public class PositionCharacterMovement : BaseCharacterMovement
    { 
        private Vector2 _nextMove = Vector2.zero;
        private Vector2 _prevPos;
        private Vector2 _targetPos;

        [SerializeField]
        private float _acceleration;

        [SerializeField]
        private float _decceleration;
       
        public override void Move(Vector2 moveVector)
        {
            float desiredSpeed = moveVector.x * _maxSpeed;
            float acceleration = Input.GetAxisRaw("Horizontal") != 0 ? _acceleration : _decceleration;

            moveVector.x = Mathf.MoveTowards(moveVector.x, desiredSpeed * Time.deltaTime, _acceleration * Time.deltaTime);

            _nextMove += moveVector;

            _prevPos = _rb2D.position;
            _targetPos = _prevPos + _nextMove;
            _newVelocity = (_targetPos - _prevPos) / Time.deltaTime;

            _rb2D.MovePosition(_targetPos);

            _nextMove = Vector2.zero;
        }

        public override bool HasGroundCollisions()
        {
            throw new NotImplementedException();
        }
    }
}
