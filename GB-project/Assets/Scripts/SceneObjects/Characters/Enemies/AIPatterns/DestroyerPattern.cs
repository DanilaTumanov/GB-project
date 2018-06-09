using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    /// <summary>
    /// Враг идет убивать базу, игнорируя игрока.
    /// </summary>
    public class DestroyerPattern : AIPattern
    {
        public DestroyerPattern(BaseEnemyController enemy) : base(enemy)
        {
        }

        public override AIStateMachine GetSM()
        {
            AIStateMachine stateMachine = new AIStateMachine(_enemy);
            stateMachine.AddState("Idle", Idle);
            stateMachine.AddState("Triggered", Triggered);
            return stateMachine;
        }
    }
}
