using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGame
{
    public enum GameType
    {
        FreeForAll,
        Duel,
        Teams,
        OneVsAll
    }
    [CreateAssetMenu(fileName = "MiniGameDeclarator", menuName = "Scriptable Objects/MiniGameDeclarator")]
    public class MiniGameDeclarator : ScriptableObject
    {
        public string gameName;
        public Scene gameScene;
        public GameType gameType;
    }
}
