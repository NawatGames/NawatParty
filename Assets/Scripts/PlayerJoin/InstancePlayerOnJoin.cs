using Generic;
using Player;
using UnityEngine;

namespace PlayerJoin
{
    public class InstancePlayerOnJoin : MonoBehaviour
    {
        private PlayerManager _playerManager;

        [SerializeField] private GameObject playerPrefab;

        private void Start()
        {
            _playerManager = PlayerManager.Instance;
            _playerManager.onPlayerRegister.AddListener(OnPlayerJoin);
        }

        private void OnDisable()
        {
            _playerManager.onPlayerRegister.RemoveListener(OnPlayerJoin);
        }

        private void OnPlayerJoin(PlayerInstance player)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform);
            newPlayer.GetComponent<GenericPlayerMovement>().Initialize(player);
        }
    }
}
