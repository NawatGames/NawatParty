using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Utils;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public List<PlayerInstance> Players { get; private set; } = new List<PlayerInstance>();
        private int _playerCount = 0;

        public UnityEvent<PlayerInstance> onPlayerRegister;
        public UnityEvent<PlayerInstance> onPlayerDeregister;

        public void RegisterPlayer(PlayerInput playerInput)
        {
            PlayerInstance player = playerInput.gameObject.GetComponentInParent<PlayerInstance>();
            if (_playerCount > 4)
            {
                Debug.LogWarning("More than 4 players connected");
            }
            Debug.Log($"Registering player {_playerCount}");
            Players.Add(player);
            player.SetPlayerIndex(_playerCount);
            _playerCount++;

            onPlayerRegister?.Invoke(player);
        }

        public void UnregisterPlayer(PlayerInput playerInput)
        {
            PlayerInstance player = playerInput.gameObject.GetComponentInParent<PlayerInstance>();
            Players.Remove(player);
            _playerCount--;

            // Update player indexes
            for (int i = 0; i < _playerCount; i++)
            {
                Players[i].SetPlayerIndex(i);
            }

            onPlayerDeregister?.Invoke(player);
        }

        public InputEvents GetPlayerInput(int playerIndex) => Players[playerIndex].InputEvents;
    }
}
