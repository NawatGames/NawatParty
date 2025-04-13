using GameManagement.StateScripts;
using MiniGame;
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

        public void SetMiniGame(MiniGameDeclarator miniGame)
        {
            CurrentMiniGame = miniGame;
        }

        private void StartMiniGame()
        {
            onMiniGameStart.Invoke();
        }

        private void OnMiniGameEnd()
        {
            onMiniGameEnd.Invoke();
        }
    }
}
