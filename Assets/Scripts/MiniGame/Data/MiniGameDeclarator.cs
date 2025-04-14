using UnityEditor;
using UnityEngine;

namespace MiniGame.Data
{
    public enum GameType
    {
        FreeForAll,
        Duel,
        Teams,
        OneVsAll
    }

    /// <summary>
    /// Defines a mini-game's properties
    /// </summary>
    [CreateAssetMenu(fileName = "MiniGameDeclarator", menuName = "Scriptable Objects/MiniGameDeclarator")]
    public class MiniGameDeclarator : ScriptableObject
    {
        // Editor Fields
        [SerializeField] private string gameName;
        [SerializeField] private SceneAsset gameScene;
        [SerializeField] private GameType gameType;
        [SerializeField] private MiniGameInputDeclarator inputDeclarator;

        // Getters
        public string GameName => gameName;
        public SceneAsset GameScene => gameScene;
        public GameType GameType => gameType;
        public MiniGameInputDeclarator InputDeclarator => inputDeclarator;
    }
}
