using System.Text;
using Interfaces;
using UnityEngine;
using Utility;

namespace Effects
{
    [CreateAssetMenu(fileName = "Effect Stats", menuName = "Effects/EffectStats", order = 1)]

    public abstract class EffectDecorator : ScriptableObject, IEffect
    {
        [SerializeField, ColorUsage(true, true)] protected Color color;
        [SerializeField, TextArea] private string description;
        protected string trueDescription;
        private IEffect _currentEffect;

        
        
        private void OnValidate()
        {
            trueDescription = $"* {description}".TextMeshProData();
        }

        public StringBuilder GetDetails()
        {
            return _currentEffect.GetDetails().AppendLine(description);
        }

        public Color GetColor()
        {
            return color;
        }

        public float GetDuration()
        {
            throw new System.NotImplementedException();
        }

        public float GetStrength()
        {
            throw new System.NotImplementedException();
        }
    }
}
