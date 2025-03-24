using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private InputEvents inputEvents;

        public PlayerInput PlayerInput{
            get { return playerInput; }
            private set { playerInput = value; }
        }

        public InputEvents InputEvents
        {
            get { return inputEvents; }
            private set { inputEvents = value; }
        }

        public int PlayerIndex { get; private set; }

        private void Awake()
        {
            transform.parent = PlayerManager.Instance.transform;
        }

        public void OnJoin()
        {
            PlayerManager.Instance.RegisterPlayer(PlayerInput);
        }

        public void SetPlayerIndex(int index)
        {
            PlayerIndex = index;

            // Update player object name
            gameObject.name = $"PlayerInstance - {PlayerIndex}";
        }
    }
}
