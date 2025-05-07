using System.Collections.Generic;
using GameManagement;
using UnityEngine;
using Generic;
using MiniGame.Data;
using Player;
using UnityEditor;

namespace TestingScene
{
    public class ForceLoadMinigame : MonoBehaviour
    {
        [Header("Settings - DO NOT CHANGE")]
        [SerializeField] private TriggerCounter triggerCounter;
        [SerializeField] private string minigameStateName = "MiniGameState";

        [Header("Minigame Declarator")]
        [SerializeField] private MiniGameDeclarator miniGameDeclarator;

        private GameState _miniGameState;

        private void Start()
        {
            MiniGameManager.Instance.SetMiniGame(miniGameDeclarator);
            _miniGameState = GameStateMachine.Instance.States[minigameStateName];
        }

        private void OnEnable()
        {
            triggerCounter.onCountUpdate.AddListener(OnCountUpdate);
        }

        private void OnDisable()
        {
            triggerCounter.onCountUpdate.RemoveListener(OnCountUpdate);
        }

        private void OnCountUpdate(int count)
        {
            if(count != PlayerManager.Instance.PlayerCount) return;
            GameStateMachine.Instance.ChangeState(_miniGameState);
        }
    }
}
