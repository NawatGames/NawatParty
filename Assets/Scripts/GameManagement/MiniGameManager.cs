using System.Collections.Generic;
using GameManagement.StateScripts;
using MiniGame;
using MiniGame.Data;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Player;

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

        private void OnMiniGameEnd(Dictionary<int, bool> winners)
        {
            _currentMiniGameInstance.onMiniGameEnd.RemoveListener(OnMiniGameEnd);
            _currentMiniGameInstance = null;

            onMiniGameEnd.Invoke();
        }

        public List<PlayerInstance> RegisterMiniGame(MiniGameInstance game)
        {
            List<PlayerInstance> currentMinigamePlayers = PlayerManager.Instance.Players;

            // TODO: MiniGameManager should not have the responsibility to choose who will play the game
            // Move this logic to another class

            // Choose 2 random players for duel minigames
            if (CurrentMiniGame.GameType == GameType.Duel && PlayerManager.Instance.PlayerCount > 2)
            {
                List<PlayerInstance> chosenPlayers = new();
                for (int i = 0; i < 2; i++)
                {
                    int index = Random.Range(0, currentMinigamePlayers.Count);
                    chosenPlayers.Add(currentMinigamePlayers[index]);
                    currentMinigamePlayers.RemoveAt(index);
                }

                currentMinigamePlayers = chosenPlayers;
            }

            _currentMiniGameInstance = game;
            _currentMiniGameInstance.onMiniGameEnd.AddListener(OnMiniGameEnd);

            return currentMinigamePlayers;
        }
    }
}
