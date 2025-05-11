using System.Collections.Generic;
using GameManagement;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public abstract class MiniGameInstance : MonoBehaviour
    {
        private MiniGameManager _miniGameManager;

        public UnityEvent onMiniGameStart;
        public UnityEvent<Dictionary<int,int>> onMiniGameEnd;
        protected List<PlayerInstance> Players;

        private void Awake()
        {
            _miniGameManager = MiniGameManager.Instance;
            Players = _miniGameManager.RegisterMiniGame(this);
        }

        private void OnEnable()
        {
            _miniGameManager.onMiniGameStart.AddListener(MiniGameStart);
        }

        private void OnDisable()
        {
            _miniGameManager.onMiniGameStart.RemoveListener(MiniGameStart);
        }

        /// <summary>
        /// This function is called when the game scene finishes loading.
        /// Use it for MiniGame setup like instancing players, setting variables, etc...
        /// </summary>
        protected abstract void MiniGameStart();

        /// <summary>
        /// This function is called when a mini-game is finished. Use it to end the current mini-game
        /// <param name="winners">
        /// Array of booleans, indicates which players have won the game
        /// </param>
        /// </summary>
        protected virtual void MiniGameEnd(Dictionary<int,int> scores)
        {
            onMiniGameEnd.Invoke(scores);
        }
    }
}
