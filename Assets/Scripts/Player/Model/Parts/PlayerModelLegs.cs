using UnityEngine;

namespace Player.Model.Parts
{
    [CreateAssetMenu(fileName = "PlayerModelLegs", menuName = "Scriptable Objects/Player/Parts/Legs", order = 0)]
    public class PlayerModelLegs : PlayerModelPart
    {
        public Mesh leftLegMesh;
        public Mesh rightLegMesh;
    }
}
