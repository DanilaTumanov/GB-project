using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.Controllers.AI;


namespace GBproject.SceneObjects
{
    /// <summary>
    /// Базовый класс для контроллеров врагов
    /// </summary>
    public abstract class BaseEnemyController : BaseSceneObject
    {
        /// <summary>
        /// Экземпляр класса паттернов поведения ИИ.
        /// </summary>
        protected AIPattern _aiPatternsObject;

        private BaseCharacterMovement _characterMovement;
        private BaseCharacterJump _characterJump;

        public BaseEnemyController()
        {
            _characterMovement = GetComponent<BaseCharacterMovement>();
            _characterJump = GetComponent<BaseCharacterJump>();
        }
    }
}
