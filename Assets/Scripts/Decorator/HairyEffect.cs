using Effects;
using UnityEngine;

namespace Decorator
{
    public class HairyEffect : MyEffectBase
    {
        private static MyEffectStats instance;

        public HairyEffect() : base()
        {
            if (instance == null)
                instance = Resources.Load<MyEffectStats>("HairyPotion");
            EffectColor = instance.EffectColor;
            Cost = instance.Cost;
            Description = instance.Description;
        }

        public override void ApplyTo(EffectHandler effectHandler)
        {
            
        }
    }
}
