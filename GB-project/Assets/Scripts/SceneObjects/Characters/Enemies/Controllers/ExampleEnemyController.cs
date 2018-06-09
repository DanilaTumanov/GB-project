using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.Controllers.AI;

namespace GBproject.SceneObjects
{
    class ExampleEnemyController : BaseEnemyController
    {
        private void Awake()
        {
            //Добавляем возможные методы поведения
            _stateMachine.AddState("Idle", _aiPatternsObject.Idle);
            _stateMachine.AddState("Triggered", _aiPatternsObject.Triggered);
        }
    }
}
