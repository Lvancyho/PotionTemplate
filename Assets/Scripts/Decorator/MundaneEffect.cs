using Effects;
using UnityEngine;

namespace Decorator
{
    public class MundaneEffect : MyEffectBase
    {
        private static MyEffectStats instance;

        public MundaneEffect() : base()
        {
            if (instance == null)
                instance = Resources.Load<MyEffectStats>("MundanePotion");
            EffectColor = instance.EffectColor;
            Cost = instance.Cost;
            Description = instance.Description;
        }

        public override void ApplyTo(EffectHandler effectHandler)
        {
            
        }
    }
}
