using System;
using Input;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniGames.ButtonMasher.Scripts
{
    public class PlayerPressCounter : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private InputEvents _inputEvents;
        public int Count { get; private set; }

        public void Setup(PlayerInstance instance)
        {
            _inputEvents = instance.InputEvents;
            _inputEvents.OnAction1Event += ButtonPress;
        }

        private void OnDisable()
        {
            _inputEvents.OnAction1Event -= ButtonPress;
        }

        private void ButtonPress(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            Count++;
        }
    }
}
