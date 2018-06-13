using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    /// <summary>
    /// Враг идет убивать базу, игнорируя игрока.
    /// </summary>
    public class DestroyerPattern : AIPattern, IAIStateIdle, IAIStatePatrol
    {
        public DestroyerPattern(BaseEnemyController enemy) : base(enemy)
        {
            _stateMachine = new AIStateMachine(_enemy);
            //TODO: реализовать рефлексию типов
            _stateMachine.AddState("Idle", AIStateIdle);
            _stateMachine.AddState("Triggered", AIStatePatrol);
        }

        public IEnumerator AIStateIdle()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator AIStatePatrol()
        {
            throw new System.NotImplementedException();
        }
    }
}
