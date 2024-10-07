using Effects;
using Interfaces;
using UnityEngine;

namespace Decorator
{
    public abstract class MyEffectBase : IMyEffect
    {
        
        protected string Description;
        protected Color EffectColor;
        protected float Cost;
        
        public string GetDescription()
        {
            return Description;
        }

        public Color GetEffectColor()
        {
            return EffectColor;
        }

        public float GetCost()
        {
            return Cost;
        }

        public abstract void ApplyTo(EffectHandler effectHandler);
        

        public void PushEffect(IMyEffect effect)
        {
            Description += "\n- " + effect.GetDescription();
            Cost += effect.GetCost();
            EffectColor *= effect.GetEffectColor();
        }
    }
}
