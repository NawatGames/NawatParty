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
    [CreateAssetMenu(fileName = "MiniGameDeclarator", menuName = "Scriptable Objects/MiniGame/MiniGameDeclarator")]
    public class MiniGameDeclarator : ScriptableObject
    {
        // Editor Fields
        [SerializeField] private string gameName;
        [TextArea(3, 5)]
        [SerializeField] private string gameDescription;
        [SerializeField] private SceneAsset gameScene;
        [SerializeField] private GameType gameType;
        [SerializeField] private MiniGameInputDeclarator inputDeclarator;

        // Getters
        public string GameName => gameName;
        public string GameDescription => gameDescription;
        public SceneAsset GameScene => gameScene;
        public GameType GameType => gameType;
        public MiniGameInputDeclarator InputDeclarator => inputDeclarator;
    }
}
