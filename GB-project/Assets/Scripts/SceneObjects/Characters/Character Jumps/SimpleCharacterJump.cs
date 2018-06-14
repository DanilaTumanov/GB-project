using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(BaseCharacterMovement))]

    public class SimpleCharacterJump : BaseCharacterJump
    {     
        private BaseCharacterMovement _characterMovement;

        protected override void Awake()
        {
            base.Awake();
            _characterMovement = GetComponent<BaseCharacterMovement>();
        }

        public override void Jump(float jumpAmount)
        {
            if (_characterMovement.HasGroundCollisions())            
                _rb2D.AddForce(Vector2.up*_jumpForce, ForceMode2D.Impulse);//_rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);                            
        }
    }
}
