using System;
using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(BaseCharacterMovement))]

    public class SimpleCharacterJump : BaseCharacterJump
    {
        private BaseCharacterMovement _characterMovement;

        protected virtual void Awake()
        {
            base.Awake();
            _characterMovement = GetComponent<BaseCharacterMovement>();
        }

        public override void Jump(float jumpAmount)
        {
            if(_characterMovement.HasGroundCollisions())            
                _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpAmount*_jumpForce);            
        }
    }
}
