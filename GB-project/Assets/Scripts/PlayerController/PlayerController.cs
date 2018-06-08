/* 
 Пока выполняет только роль PlayerInputController 
 т.е. получает ввод и двигает за счет этого персонажа
 */
using UnityEngine;

namespace GBproject.SceneObjects
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : BaseSceneObject
    {
        private CharacterMovement characterMovement;
        private Vector3 movement = Vector3.zero;

        void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
        }

        void Update()
        {
            movement.x = Input.GetAxis("Horizontal"); 
            //movement.y = Input.GetAxis("Vertical");            

            characterMovement.Move(movement);
        }
    }
}

