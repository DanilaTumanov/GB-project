using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBproject.SceneObjects;

namespace GBproject.Controllers.AI
{
    interface IAIStateIdle
    {
        /// <summary>
        /// Враг ожидает.
        /// </summary>
        IEnumerator AIStateIdle();
    }
}
