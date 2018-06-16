using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(Rigidbody2D))]
    /// <summary>
    /// Базовый класс передвижения персонажей
    /// </summary>
    public abstract class BaseCharacterMovement : MonoBehaviour
    {
        protected Rigidbody2D _rb2D;
        protected Vector2 _newVelocity;

        [Tooltip("Скорость перемещения персонажа. Умножает введенный вектор перемещения")]
        [SerializeField]
        protected float _maxSpeed = 1f;

        protected virtual void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Перемещение персонажа в указанном направлении.
        /// </summary>
        /// <param name="movement">направление и величина перемещения</param>
        public abstract void Move(Vector2 moveVector);

        /// <summary>
        /// Проверка, есть ли "почва под ногами". Обычно вызывается при прыжке.
        /// </summary>
        public abstract bool HasGroundCollisions();
    }
}
