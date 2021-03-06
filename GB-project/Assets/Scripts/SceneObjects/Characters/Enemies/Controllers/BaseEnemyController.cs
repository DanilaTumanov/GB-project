﻿using System.Collections;
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
        protected AIPattern _aiPatternsObject;
    }
}
