using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(Rigidbody2D))]
    /// <summary>
    /// Базовый класс, отвечающий за прыжки
    /// </summary>
    public abstract class BaseCharacterJump : MonoBehaviour
    {
        protected Rigidbody2D _rb2D;

        [Tooltip("Сила применяемая для толчка персонажа вверх.")]
        [SerializeField]
        protected float _jumpForce = 2f;

        protected virtual void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }

        public abstract void Jump(float jumpAmount);
    }
}
