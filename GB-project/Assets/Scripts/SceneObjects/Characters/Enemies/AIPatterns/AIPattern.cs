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
        public IEnumerator Idle()
        {
            return null;
        }

        /// <summary>
        /// Враг спровоцирован.
        /// </summary>
        public IEnumerator Triggered()
        {
            return null;
        }

        /// <summary>
        /// Враг идет убивать базу, игнорируя игрока.
        /// </summary>
        public IEnumerator Patrol()
        {
            return null;
        }
    }
}
