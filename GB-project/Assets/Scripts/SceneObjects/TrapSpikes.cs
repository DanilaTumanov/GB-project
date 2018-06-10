using GBproject.Interfaces;
using UnityEngine;

namespace GBproject.SceneObjects
{
    [DisallowMultipleComponent]
    public class TrapSpikes : BaseTrap, IDamageDealer
    {
        [SerializeField]
        [Tooltip("Наносимый урон")]
        private float _damage;

        public float GetDamage()
        {
            return _damage;
        }

        protected override void Interact(Collision2D collision)
        {
            var _damageableObject = collision.collider.gameObject.GetComponent<IDamageable>();
            if (_damageableObject != null)
            {
                DealDamage(_damageableObject);
            }
        }

        private void DealDamage(IDamageable damageableObject)
        {
            damageableObject.ApplyDamage(this as IDamageDealer);
        }
    }
}