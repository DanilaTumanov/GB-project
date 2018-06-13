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
            _aiPatternsObject = new DestroyerPattern(this);
        }
    }
}
