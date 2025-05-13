using System.Collections;
using System.Collections.Generic;
using MiniGame;
using Player;
using Player.Model;
using UnityEngine;

namespace MiniGames.ButtonMasher.Scripts
{
    public class ButtonMasher : MiniGameInstance
    {
        [SerializeField] private float gameDuration = 120;
        [SerializeField] private List<PlayerPressCounter> playerPressCounters;

        protected override void MiniGameStart()
        {
            foreach (PlayerInstance player in Players)
            {
                PlayerPressCounter counter  = playerPressCounters[player.PlayerIndex];
                // Setup miniGame scripts
                counter.gameObject.SetActive(true);
                counter.Setup(player);
                // Load player model
                counter.gameObject.GetComponentInChildren<PlayerModelApplier>().LoadModel(player.PlayerModel);
            }

            StartCoroutine(WaitGameTime());
        }

        private IEnumerator WaitGameTime()
        {
            yield return new WaitForSeconds(gameDuration);
            CalculateScore();
        }

        private void CalculateScore()
        {
            Dictionary<PlayerInstance, int> score = new();
            foreach (PlayerInstance player in Players)
            {
                score.Add(player, playerPressCounters[player.PlayerIndex].Count);
            }
            MiniGameEnd(score);
        }
    }
}
