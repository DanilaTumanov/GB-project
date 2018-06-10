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
            var _damagableObject = collision.collider.gameObject.GetComponent<IDamagable>();
            if (_damagableObject != null)
            {
                DealDamage(_damagableObject);
            }
        }

        private void DealDamage(IDamagable _damagableObject)
        {
            _damagableObject.ApplyDamage(this as IDamageDealer);
        }
    }
}