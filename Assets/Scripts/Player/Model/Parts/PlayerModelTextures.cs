using System.Collections.Generic;
using UnityEngine;

namespace Player.Model.Parts
{
    [CreateAssetMenu(fileName = "PlayerModelTextures", menuName = "Scriptable Objects/Player/Parts/Textures", order = 0)]
    public class PlayerModelTextures : ScriptableObject
    {
        public List<Texture2D> textures;
    }
}
