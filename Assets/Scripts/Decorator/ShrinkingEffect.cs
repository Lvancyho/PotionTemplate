using Effects;
using UnityEngine;

namespace Decorator
{
    public class ShrinkingEffect : MyEffectBase
    {
        private static MyEffectStats instance;

        public ShrinkingEffect() : base()
        {
            if (instance == null)
                instance = Resources.Load<MyEffectStats>("ShrinkingPotion");
            EffectColor = instance.EffectColor;
            Cost = instance.Cost;
            Description = instance.Description;
        }

        public override void ApplyTo(EffectHandler effectHandler)
        {
            
        }
    }
}
