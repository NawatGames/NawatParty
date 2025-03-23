using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }
        public List<PlayerInstance> Players { get; private set; } = new List<PlayerInstance>();
        private int _playerCount = 0;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("More than one player manager in the scene!");
                Destroy(this);
            }
            Instance = this;
        }

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
        }
    }
}
