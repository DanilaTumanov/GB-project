using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    interface IAIStatePatrol
    {
        /// <summary>
        /// Враг патрулирует.
        /// </summary>
        IEnumerator AIStatePatrol();
    }
}
