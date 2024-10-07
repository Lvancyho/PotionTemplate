using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "MyEffectStats", menuName = "ScriptableObjects/MyEffectStats")]
    public class MyEffectStats : ScriptableObject
    {
        [SerializeField, TextArea] private string description;
        [SerializeField, ColorUsage(false, true)] private Color effectColor;
        [SerializeField,Min(0)] private float cost;

        public string Description => description;
        public Color EffectColor => effectColor;
        public float Cost  => cost;
    }
}
