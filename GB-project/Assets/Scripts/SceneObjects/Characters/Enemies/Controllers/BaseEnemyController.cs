using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.Controllers.AI;


namespace GBproject.SceneObjects
{
    /// <summary>
    /// Базовый класс для контроллеров врагов
    /// </summary>
    public class BaseEnemyController : BaseSceneObject
    {
        /// <summary>
        /// Экземпляр класса паттернов поведения ИИ.
        /// </summary>
        protected AIPatterns _aiPatternsObject;

        /// <summary>
        /// КА для управления поведением врага.
        /// </summary>
        protected AIStateMachine _stateMachine;

        private void Awake()
        {
            _aiPatternsObject = new AIPatterns(this);
            _stateMachine = new AIStateMachine(this);
        }
    }
}
