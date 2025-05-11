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

        [SerializeField] private Animator animator;
        private bool isWalking = false;

        private InputEvents _playerInput;

        private Vector2 _axis;

        private Vector3 _camDirection;

        private void Awake()
        {
            _camDirection = Camera.main.transform.forward;
            _camDirection.y = 0f;
            _camDirection = _camDirection.normalized;
        }

        public void Initialize(PlayerInstance player)
        {
            playerIndex = player.PlayerIndex;
            SetPlayerIndex(playerIndex);
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
            if (axis == Vector2.zero)
            {
                isWalking = false;
                animator.Play("Idle");
            }
            else if (!isWalking)
            {
                isWalking = true;
                animator.Play("Walking_A");
            }
        }

        private void Update()
        {

            // Update player speed
            Vector3 direction = _camDirection * _axis.y + Vector3.Cross(_camDirection, Vector3.up) * -_axis.x;
            rb.linearVelocity = new Vector3(0f,rb.linearVelocity.y,0f);
            rb.linearVelocity += direction.normalized * moveSpeed;

            // Rotate player according to movement
            if(_axis.sqrMagnitude == 0) return;
            Quaternion targetAngle = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * 10f);
        }

        public bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, playerHeight);

        private void OnJump(InputAction.CallbackContext context)
        {
            if (!canJump || context.canceled || !IsGrounded()) return;
            rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
        }
    }
}
