using System;
using UnityEngine;

namespace MiniGames.ButtonMasher.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerPressCounter pressCounter;
        [SerializeField] private Animator animator;

        private float _pressInterval = 0;
        private float _lastPressTime = 0;
        private void OnEnable()
        {
            animator.Play("Spawn_Air");
            _lastPressTime = Time.time;
            pressCounter.onPress.AddListener(OnPress);
        }

        private void OnDisable()
        {
            pressCounter.onPress.RemoveListener(OnPress);
        }

        private void OnPress()
        {
            animator.Play("1H_Melee_Attack_Slice_Diagonal");
            _pressInterval = Time.time - _lastPressTime;
            _lastPressTime = Time.time;
        }

        private void Update()
        {
            animator.speed = 1f / _pressInterval;
        }
    }
}
