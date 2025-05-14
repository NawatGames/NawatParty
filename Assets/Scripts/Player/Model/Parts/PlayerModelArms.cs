using UnityEngine;

namespace Player.Model.Parts
{
    [CreateAssetMenu(fileName = "PlayerModelArms", menuName = "Scriptable Objects/Player/Parts/Arms", order = 0)]
    public class PlayerModelArms : PlayerModelPart
    {
        public Mesh leftArmMesh;
        public Mesh rightArmMesh;
    }
}
