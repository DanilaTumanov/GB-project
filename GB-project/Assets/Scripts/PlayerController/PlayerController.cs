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
        private Vector3 movement;
        void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
        }

        void Update()
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            characterMovement.Move(movement);
        }
    }
}

