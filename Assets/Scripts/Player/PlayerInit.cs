using Player.Model;
using UnityEngine;

namespace Player
{
    public class PlayerInit : MonoBehaviour
    {
        [SerializeField] private PlayerModelApplier playerModelApplier;

        private PlayerInstance _playerInstance;

        public void Init(PlayerInstance playerInstance)
        {
            _playerInstance = playerInstance;
            playerModelApplier.LoadModel(_playerInstance.PlayerModel);
        }
    }
}
