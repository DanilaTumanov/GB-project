using UnityEngine;

namespace GBproject
{
    public class JetPackJump : BaseCharacterJump
    {
        [Tooltip("Максимальная скорость полета")]
        [SerializeField]
        private float _maxVerticalSpeed = 3f;

        public override void Jump(float jumpAmount)
        {
            if (_rb2D.velocity.y < _maxVerticalSpeed)                
                _rb2D.AddForce(new Vector2(0f, jumpAmount*_jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }
}
