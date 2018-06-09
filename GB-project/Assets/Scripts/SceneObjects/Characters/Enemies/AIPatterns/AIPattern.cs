using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    /// <summary>
    /// Класс, содержащий паттерны поведения врагов.
    /// </summary>
    public abstract class AIPattern
    {
        /// <summary>
        /// Ссылка на управляемый объект.
        /// </summary>
        protected BaseEnemyController _enemy;

        public AIPattern(BaseEnemyController enemy)
        {
            _enemy = enemy;
        }

        /// <summary>
        /// Метод возвращает КА для заданного поведения врага. 
        /// </summary>
        public abstract AIStateMachine GetSM();

        /// <summary>
        /// Враг ожидает.
        /// </summary>
        public IEnumerator AIStateIdle()
        {
            return null;
        }

        /// <summary>
        /// Враг спровоцирован.
        /// </summary>
        public IEnumerator AIStateTriggered()
        {
            return null;
        }

        /// <summary>
        /// Враг патрулирует.
        /// </summary>
        public IEnumerator AIStatePatrol()
        {
            return null;
        }
    }
}
