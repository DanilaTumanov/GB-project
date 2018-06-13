using UnityEngine;

namespace GBproject
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    /// <summary>
    /// Класс передвижения персонажей за счет прямого задания вектора скорости.
    /// </summary>
    public class VelocityCharacterMovement : BaseCharacterMovement
    {
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

        Vector2[] _raycastPositions = new Vector2[3];

        protected virtual void Awake()
        {
            base.Awake();
            _collider = GetComponent<Collider2D>();
        }
        /// <summary>
        /// Перемещение персонажа в указанном направлении за счет задания вектора скорости.
        /// </summary>
        /// <param name="movement">направление перемещения и процент от максимальной скорости в нужном направлении</param>
        public override void Move(Vector2 moveVector)
        {
            /// Установка горизонтального перемещения
            _newVelocity.x = moveVector.x * _maxSpeed;

            /// Установка вертикального перемещения (для этого проверяем не на лестнице ли мы.)
            _raycastHit = Physics2D.Raycast(transform.position, Vector2.up * moveVector.y, _stairsRaycastDistance, _stairsLayerMask);
            if (_raycastHit.collider)
            {
                _newVelocity.y = moveVector.y * _maxSpeed;
                _rb2D.gravityScale = 0;
            }
            else
            {                               
                _newVelocity.y = _rb2D.velocity.y;
                _rb2D.gravityScale = 1;
            }

            /// Установка суммарного вектора скорости
            _rb2D.velocity =_newVelocity;
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