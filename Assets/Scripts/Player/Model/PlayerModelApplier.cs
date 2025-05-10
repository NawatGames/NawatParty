using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Model
{
    public class PlayerModelApplier : MonoBehaviour
    {
        [Header("Skinned Mesh Renderers")]
        [SerializeField] private SkinnedMeshRenderer headMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer bodyMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer leftArmMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer rightArmMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer leftLegMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer rightLegMeshRenderer;

        [SerializeField] private PlayerModelDeclarator initialModelDeclarator;

        private void Awake()
        {
            if(initialModelDeclarator) LoadModel(initialModelDeclarator);
        }

        public void LoadModel(PlayerModelDeclarator declarator)
        {
            // Set Head
            headMeshRenderer.sharedMesh = declarator.headPart;
            headMeshRenderer.material.mainTexture = declarator.headTexture2D;

            // Set Body
            bodyMeshRenderer.sharedMesh = declarator.bodyPart;
            bodyMeshRenderer.material.mainTexture = declarator.bodyTexture;

            // Set Legs
            leftLegMeshRenderer.sharedMesh = declarator.leftLegPart;
            leftLegMeshRenderer.material.mainTexture = declarator.bodyTexture;

            rightLegMeshRenderer.sharedMesh = declarator.rightLegPart;
            rightLegMeshRenderer.material.mainTexture = declarator.bodyTexture;

            // Set Arms
            leftArmMeshRenderer.sharedMesh = declarator.leftArmPart;
            leftArmMeshRenderer.material.mainTexture = declarator.bodyTexture;

            rightArmMeshRenderer.sharedMesh = declarator.rightArmPart;
            rightArmMeshRenderer.material.mainTexture = declarator.bodyTexture;
        }
    }
}
