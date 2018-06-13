using UnityEngine;

namespace GBproject
{
    /// <summary>
    /// Класс передвижения персонажей за счет прямого задания вектора скорости.
    /// </summary>
    public class VelocityCharacterMovement : BaseCharacterMovement
    {
        [Tooltip("Слои объектов, позволяющих персонажу перемещаться вертикально: лестницы, канаты.")]        
        [SerializeField]
        private LayerMask stairsLayerMask;
        [Tooltip("Рясстояние для проверки лестниц под ногами.")]
        [SerializeField]
        private float stairsDownRaycastDistance = 0.1f;

        Collider2D _collider;
        ContactFilter2D _contactFilter;

        protected override void Awake()
        {
            base.Awake();
            _collider = GetComponent<Collider2D>();

            _contactFilter.layerMask = stairsLayerMask;
            _contactFilter.useLayerMask = true;
            _contactFilter.useTriggers = true;

            Physics2D.queriesStartInColliders = false;
        }


        /// <summary>
        /// Перемещение персонажа в указанном направлении за счет задания вектора скорости.
        /// </summary>
        /// <param name="movement">направление перемещения и процент от максимальной скорости в нужном направлении</param>
        public override void Move(Vector2 moveVector)
        { 
            _newVelocity.Set(moveVector.x * _maxSpeed, _rb2D.velocity.y);
            _rb2D.velocity =_newVelocity;           
        }


        RaycastHit2D[] m_HitBuffer = new RaycastHit2D[5];
        RaycastHit2D[] m_FoundHits = new RaycastHit2D[3];
        Collider2D[] m_GroundColliders = new Collider2D[3];
        Vector2[] m_RaycastPositions = new Vector2[3];
        public void ChechForStairs()
        {
            Vector2 raycastDirection;
            Vector2 raycastStart;
            float raycastDistance;

            if (_collider)
            {
                raycastStart = m_Rigidbody2D.position + m_Capsule.offset;
                raycastDistance = m_Capsule.size.x * 0.5f + groundedRaycastDistance * 2f;

                if (bottom)
                {
                    raycastDirection = Vector2.down;
                    Vector2 raycastStartBottomCentre = raycastStart + Vector2.down * (m_Capsule.size.y * 0.5f - m_Capsule.size.x * 0.5f);

                    m_RaycastPositions[0] = raycastStartBottomCentre + Vector2.left * m_Capsule.size.x * 0.5f;
                    m_RaycastPositions[1] = raycastStartBottomCentre;
                    m_RaycastPositions[2] = raycastStartBottomCentre + Vector2.right * m_Capsule.size.x * 0.5f;
                }
                else
                {
                    raycastDirection = Vector2.up;
                    Vector2 raycastStartTopCentre = raycastStart + Vector2.up * (m_Capsule.size.y * 0.5f - m_Capsule.size.x * 0.5f);

                    m_RaycastPositions[0] = raycastStartTopCentre + Vector2.left * m_Capsule.size.x * 0.5f;
                    m_RaycastPositions[1] = raycastStartTopCentre;
                    m_RaycastPositions[2] = raycastStartTopCentre + Vector2.right * m_Capsule.size.x * 0.5f;
                }
            }
        }
    }
}