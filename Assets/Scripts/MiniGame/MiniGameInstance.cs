using GameManagement;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public abstract class MiniGameInstance : MonoBehaviour
    {
        private MiniGameManager _miniGameManager;

        public UnityEvent onMiniGameStart;
        public UnityEvent onMiniGameEnd;

        private void OnEnable()
        {
            _miniGameManager = MiniGameManager.Instance;
            _miniGameManager.onMiniGameStart.AddListener(MiniGameStart);
        }

        private void OnDisable()
        {
            _miniGameManager.onMiniGameStart.RemoveListener(MiniGameStart);
        }

        private void Start()
        {
            _miniGameManager.RegisterMiniGame(this);
            MiniGameStart();
        }

        /// <summary>
        /// This function is called when the game scene finishes loading.
        /// Use it for MiniGame setup like instancing players, setting variables, etc...
        /// </summary>
        protected abstract void MiniGameStart();

        /// <summary>
        /// This function is called when a mini-game is finished. Use it to end the current mini-game
        /// </summary>
        protected virtual void MiniGameEnd()
        {
            onMiniGameEnd.Invoke();
        }
    }
}
