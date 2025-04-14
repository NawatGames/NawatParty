using GameManagement.StateScripts;
using MiniGame;
using MiniGame.Data;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace GameManagement
{
    public class MiniGameManager : Singleton<MiniGameManager>
    {
        [SerializeField] private MiniGameLoader miniGameLoader;
        public MiniGameDeclarator CurrentMiniGame { get; private set; }

        public UnityEvent onMiniGameStart;
        public UnityEvent onMiniGameEnd;

        private MiniGameInstance _currentMiniGameInstance;

        public void SetMiniGame(MiniGameDeclarator miniGame)
        {
            CurrentMiniGame = miniGame;
        }

        private void StartMiniGame()
        {
            onMiniGameStart.Invoke();
        }

        private void OnMiniGameEnd(bool[] winners)
        {
            _currentMiniGameInstance.onMiniGameEnd.RemoveListener(OnMiniGameEnd);
            _currentMiniGameInstance = null;

            onMiniGameEnd.Invoke();
        }

        public void RegisterMiniGame(MiniGameInstance game)
        {
            _currentMiniGameInstance = game;
            _currentMiniGameInstance.onMiniGameEnd.AddListener(OnMiniGameEnd);
        }
    }
}
