using UnityEngine;

namespace MiniGame.Data
{
    public enum AxisType
    {
        Horizontal,
        Vertical,
        Full
    }

    /// <summary>
    /// Defines a mini-game's input mapping
    /// </summary>
    [CreateAssetMenu(fileName = "MiniGameInputDeclarator", menuName = "Scriptable Objects/MiniGame/MiniGameInputDeclarator")]
    public class MiniGameInputDeclarator : ScriptableObject
    {
        // Editor Fields
        [SerializeField] private AxisType axisType;
        [SerializeField] private string axisDescription;

        [SerializeField] private string northButtonDescription;
        [SerializeField] private string southButtonDescription;
        [SerializeField] private string eastButtonDescription;
        [SerializeField] private string westButtonDescription;

        // Getters
        public AxisType InputAxisType => axisType;
        public string InputAxisDescription => axisDescription;

        public string NorthButtonDescription => northButtonDescription;
        public string SouthButtonDescription => southButtonDescription;
        public string EastButtonDescription => eastButtonDescription;
        public string WestButtonDescription => westButtonDescription;
    }
}
