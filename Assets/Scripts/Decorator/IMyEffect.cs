using Effects;
using UnityEngine;

namespace Decorator
{
    public interface IMyEffect
    {
        public string GetDescription();
        public Color GetEffectColor();
        public float GetCost();
        
        public void ApplyTo(EffectHandler effectHandler);
        
        
    }
}
