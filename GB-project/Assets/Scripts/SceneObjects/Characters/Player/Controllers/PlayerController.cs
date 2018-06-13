using UnityEngine;

namespace GBproject.SceneObjects
{
    /// <summary>
    /// Пока выполняет только роль PlayerInputController 
    /// т.е.получает ввод и двигает за счет этого персонажа
    /// </summary>
    [RequireComponent(typeof(BaseCharacterMovement))]
    [DisallowMultipleComponent]
    public class PlayerController : BaseSceneObject
    {
        private BaseCharacterMovement _characterMovement;
        private Vector2 _moveInput = Vector2.zero;
        
        void Awake()
        {
            _characterMovement = GetComponent<BaseCharacterMovement>();
        }
        void Update()
        {
            _moveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));            
        }
        void FixedUpdate()
        {            
            _characterMovement.Move(_moveInput);
        }
    } 
}

