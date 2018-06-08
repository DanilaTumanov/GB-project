using UnityEngine;


namespace GBproject.SceneObjects
{

    /// <summary>
    /// Пока выполняет только роль PlayerInputController 
    /// т.е.получает ввод и двигает за счет этого персонажа
    /// </summary>
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : BaseSceneObject
    {
        private CharacterMovement _characterMovement;
        private Vector3 _movement = Vector3.zero;

        void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        void Update()
        {
            _movement.x = Input.GetAxis("Horizontal"); 
            //movement.y = Input.GetAxis("Vertical");            

            _characterMovement.Move(_movement);
        }
    }
}

