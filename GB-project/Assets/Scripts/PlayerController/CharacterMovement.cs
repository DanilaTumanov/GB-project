using UnityEngine;

namespace GBproject
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        protected float _moveSpeed = 1f;

        /// <summary>
        /// Перемещение персонажа в указанном направлении
        /// </summary>
        /// <param name="movement">вектор направления</param>
        public void Move(Vector3 movement)
        {
            transform.position += movement * Time.deltaTime * _moveSpeed;
        }
    }
}
