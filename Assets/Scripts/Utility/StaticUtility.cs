using UnityEngine;

namespace Utility
{
    public static class StaticUtility
    {
        public static readonly int DefaultLayer = 1<<LayerMask.NameToLayer("Default");
        public static readonly int WaterLayer = 1<<LayerMask.NameToLayer("Water");
        public static readonly int EnemyLayer = 1<<LayerMask.NameToLayer("Enemy");
        public static readonly int PlayerLayer = 1<<LayerMask.NameToLayer("Player");
        private static readonly int UILayer = 1<<LayerMask.NameToLayer("UI");
        private static readonly int IgnoreLayer = 1<<LayerMask.NameToLayer("Ignore Raycast");
        private static readonly int FXLayer = 1<<LayerMask.NameToLayer("TransparentFX");
        public static readonly int GroundLayers = DefaultLayer;
        
        public static readonly int GrabLayers = DefaultLayer;
    }
}
