using GBproject.Interfaces;
using UnityEngine;

namespace GBproject.SceneObjects
{
    /// <summary>
    /// Базовый функционал ловушек.
    /// </summary>
    public abstract class BaseTrap : BaseSceneObject
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _trapableObject = collision.collider.gameObject.GetComponent<ITrapable>();
            if (_trapableObject != null)
            {
                _trapableObject.Trapped();
                Interact(collision);
            }
        }

        /// <summary>
        /// Метод обертка, вызывается при пересечении другим объектом коллайдера ловушки. Отвечает за взаимодействие ловушки и объекта.
        /// </summary>
        /// <param name="collision">Информация о коллизии.</param>
        protected abstract void Interact(Collision2D collision);
    }
}