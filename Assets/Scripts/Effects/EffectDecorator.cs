
using Interfaces;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "Effect Stats", menuName = "Effects/EffectStats", order = 1)]

    public abstract class EffectDecorator : ScriptableObject, IEffect
    {
        [SerializeField] private EffectDecorator test2;
        [SerializeField, ColorUsage(true, true)] protected Color color;
        [SerializeField, TextArea] protected string description;
            
        private IEffect _currentEffect;
        
        
        
        public void ApplyTo(EffectHandler handler)
        {
            throw new System.NotImplementedException();
        }

        public string GetDetails()
        {
            throw new System.NotImplementedException();
        }

        public Color GetColor()
        {
            throw new System.NotImplementedException();
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
