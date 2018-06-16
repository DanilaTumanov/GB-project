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
        private BaseCharacterJump _characterJump;
        private Vector2 _moveInput = Vector2.zero;
        private float _jumpInput = 0.0f;

        void Awake()
        {
            _characterMovement = GetComponent<BaseCharacterMovement>();
            _characterJump = GetComponent<BaseCharacterJump>();
        }

        void Update()
        {
            _moveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _jumpInput = Input.GetAxis("Jump");
        }

        void FixedUpdate()
        {
            _characterMovement.Move(_moveInput);

            if(_jumpInput > 0)
                _characterJump.Jump(_jumpInput);
        }
    } 
}

