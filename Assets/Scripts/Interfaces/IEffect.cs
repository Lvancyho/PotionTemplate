using Effects;
using UnityEngine;

namespace Interfaces
{
    public interface IEffect
    {
        public void ApplyTo(EffectHandler handler);
        public string GetDetails();
        public Color GetColor();
        public float GetDuration();
        public float GetStrength();
    }
}
