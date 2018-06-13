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

        /// <summary>
        /// КА для управления поведением врага.
        /// </summary>
        protected AIStateMachine _stateMachine;

        public AIPattern(BaseEnemyController enemy)
        {
            _enemy = enemy;
        }
    }
}
