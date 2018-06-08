using System.Collections;
using UnityEngine;

namespace GBproject.SceneObjects
{
    /// <summary>
    /// Базовый функционал ловушек.
    /// </summary>
    public abstract class BaseTrap : BaseSceneObject
    {
        /// <summary>
        /// Задержка в секундах перед срабатыванием ловушки.
        /// </summary>
        [SerializeField]
        private float _delayBeforeTrapActivation;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(DoInteraction(collision, _delayBeforeTrapActivation));
        }

        /// <summary>
        /// Корутина дает возможность отложить срабатывание ловушки.
        /// </summary>
        /// <param name="collision">Информация о коллизии.</param>
        /// <param name="delay">Задержка в секундах.</param>
        /// <returns></returns>
        IEnumerator DoInteraction(Collision2D collision, float delay)
        {
            if (delay > 0.0f)
            {
                yield return new WaitForSeconds(delay);
            }

            Interact(collision);
        }

        /// <summary>
        /// Метод обертка, вызывается при пересечении другим объектом коллайдера ловушки. Отвечает за взаимодействие ловушки и объекта.
        /// </summary>
        /// <param name="collision">Информация о коллизии.</param>
        protected abstract void Interact(Collision2D collision);
    }
}