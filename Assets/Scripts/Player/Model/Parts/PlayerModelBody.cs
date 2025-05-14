using UnityEngine;

namespace Player.Model.Parts
{
    [CreateAssetMenu(fileName = "PlayerModelBody", menuName = "Scriptable Objects/Player/Parts/Body", order = 0)]
    public class PlayerModelBody : PlayerModelPart
    {
        public Mesh bodyMesh;
    }
}
