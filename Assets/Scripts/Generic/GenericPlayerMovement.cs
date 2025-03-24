using System;
using Input;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Generic
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class GenericPlayerMovement : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] private Rigidbody rb;
        [Header("Config")]
        [SerializeField] private int playerIndex = 0;

        [SerializeField] private float moveSpeed = 5f;

        [SerializeField] private bool canJump = true;
        [SerializeField] private float playerHeight = 1.5f;
        [SerializeField] private float jumpMultiplier = 1f;

        private InputEvents _playerInput;

        private Vector2 _axis;
        private float _currentRotationVel = 0f;

        private void OnEnable()
        {
           SetPlayerIndex(playerIndex);
        }

        private void OnDisable()
        {
            _playerInput.OnMoveEvent -= OnMove;
            _playerInput.OnJumpEvent -= OnJump;
        }

        public void SetSpeed(float newSpeed)
        {
            moveSpeed = newSpeed;
        }

        public void SetPlayerIndex(int newPlayerIndex)
        {
            if (_playerInput)
            {
                _playerInput.OnMoveEvent -= OnMove;
                _playerInput.OnJumpEvent -= OnJump;
            }
            _playerInput = PlayerManager.Instance.GetPlayerInput(newPlayerIndex);
            _playerInput.OnMoveEvent += OnMove;
            _playerInput.OnJumpEvent += OnJump;
        }

        private void OnMove(InputAction.CallbackContext context, Vector2 axis)
        {
            _axis = axis;
        }

        private void Update()
        {
            // Update player speed
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            rb.linearVelocity += new Vector3(_axis.x, 0f, _axis.y).normalized * moveSpeed;

            // Rotate player according to movement
            if(_axis.sqrMagnitude == 0) return;
            float targetAngle = Mathf.Atan2(_axis.x, _axis.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentRotationVel, .05f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        public bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, playerHeight);

        private void OnJump(InputAction.CallbackContext context)
        {
            if (!canJump || context.canceled || !IsGrounded()) return;
            rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
        }
    }
}
