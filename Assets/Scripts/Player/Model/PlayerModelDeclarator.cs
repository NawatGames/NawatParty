using UnityEngine;

namespace Player.Model
{
    [CreateAssetMenu(fileName = "PlayerModelDeclarator", menuName = "Scriptable Objects/Player/Player Model Declarator", order = 0)]
    public class PlayerModelDeclarator : ScriptableObject
    {
        public Mesh headPart;
        public Mesh bodyPart;
        public Mesh rightArmPart;
        public Mesh leftArmPart;
        public Mesh leftLegPart;
        public Mesh rightLegPart;

        public Texture2D headTexture2D;
        public Texture2D bodyTexture;
    }
}
