using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    /// <summary>
    /// Класс, содержащий паттерны поведения врагов.
    /// </summary>
    public class AIPattern
    {
        /// <summary>
        /// Ссылка на управляемый объект.
        /// </summary>
        private BaseEnemyController _enemy;

        public AIPattern(BaseEnemyController enemy)
        {
            _enemy = enemy;
        }

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
        public IEnumerator Destroyer()
        {
            return null;
        }

        /// <summary>
        /// Враг ищет игрока, игнорируя все остальное.
        /// </summary>
        public IEnumerator Hunter()
        {
            return null;
        }
    }
}
