using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    /// <summary>
    /// Класс передвижения персонажей за счет прямого задания вектора скорости.
    /// </summary>
    public class VelocityCharacterMovement : BaseCharacterMovement
    {
        [Tooltip("Скорость перемещения на лестнице уменьшается в указанное число раз отностительно базовой максимальной скорости.")]
        [SerializeField]
        private float _stairsDeceleration = 3f;
        [Tooltip("Слои объектов, позволяющих персонажу перемещаться вертикально: лестницы, канаты.")]        
        [SerializeField]
        private LayerMask _stairsLayerMask;
        [Tooltip("Рясстояние для проверки лестниц под ногами.")]
        [SerializeField]
        private float _stairsRaycastDistance = 0.1f;

        [Tooltip("Слои объектов, на которых персонаж может опираться ногами.")]
        [SerializeField]
        private LayerMask _groundLayerMask;
        [Tooltip("Рясстояние для проверки \"почвы под ногами\".")]
        [SerializeField]
        private float _groundedRaycastDistance = 0.1f;

        private RaycastHit2D _raycastHit;
        private Collider2D _collider;
        private bool _isOnStairs;
        private int _facingDir = 1; /// 1 - смотрит вправо, -1 - влево
        private float _startGravityScale;
        Vector2[] _raycastPositions = new Vector2[3];

        #region Встроенные Unity-методы
        protected override void Awake()
        {
            base.Awake();
            _collider = GetComponent<Collider2D>();
            _startGravityScale = _rb2D.gravityScale;
        }

        /// Проверяем находится ли коллайдер в одном из слоев, указанных в маске слоев для лестниц
        void OnTriggerStay2D(Collider2D other)
        {
            _isOnStairs = _stairsLayerMask == (_stairsLayerMask | (1 << other.gameObject.layer));
        }

        void OnTriggerExit2D(Collider2D other)
        {
            _isOnStairs = false;
        }
        #endregion

        /// <summary>
        /// Перемещение персонажа в указанном направлении за счет задания вектора скорости.
        /// </summary>
        /// <param name="movement">направление перемещения и процент от максимальной скорости в нужном направлении</param>
        public override void Move(Vector2 moveVector)
        {            
            if (_isOnStairs)
            {
                _rb2D.gravityScale = 0;
                                
                if      (moveVector.y != 0)        _newVelocity.Set(  0  ,  moveVector.y * _maxSpeed / _stairsDeceleration );                
                else if (!HasGroundCollisions())   _newVelocity.Set(  moveVector.x * _maxSpeed / _stairsDeceleration  , 0 );                
                else                               _newVelocity.Set(  moveVector.x * _maxSpeed  , 0);
            }
            else
            {
                _rb2D.gravityScale = _startGravityScale;

                _newVelocity.Set(moveVector.x * _maxSpeed, Mathf.Clamp(_rb2D.velocity.y, -_maxSpeed, _maxSpeed));                
            } 
                                             
            /// Установка финального вектора скорости
            _rb2D.velocity = _newVelocity;

            /// Установка финального вектора скорости
            if (moveVector.x * _facingDir < 0)    Flip();
        }
        
        private void Flip()
        {
            _facingDir *= -1;
            transform.Rotate(Vector3.up, 180);
        }

        /// <summary>
        /// Проверка, есть ли "почва под ногами". Обычно вызывается при прыжке.
        /// </summary>
        public override bool HasGroundCollisions()
        {
            Vector2 raycastStart;
            float raycastDistance;

            raycastStart = _rb2D.position + _collider.offset;
            raycastDistance = _collider.bounds.extents.x + _groundedRaycastDistance;
                        
            Vector2 raycastStartBottomCentre = raycastStart + Vector2.down * (_collider.bounds.extents.y - _collider.bounds.extents.x);

            _raycastPositions[0] = raycastStartBottomCentre + Vector2.left * _collider.bounds.extents.x;
            _raycastPositions[1] = raycastStartBottomCentre;
            _raycastPositions[2] = raycastStartBottomCentre + Vector2.right * _collider.bounds.extents.x;
            
            for (int i = 0; i < _raycastPositions.Length; i++)
            {
                _raycastHit = Physics2D.Raycast(_raycastPositions[i], Vector2.down, raycastDistance, _groundLayerMask);
                if (_raycastHit.collider)  return true;
            }

            return false;        
        }
    }
}