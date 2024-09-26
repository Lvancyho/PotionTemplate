using Interfaces;
using UnityEngine;

namespace Effects
{
    public class EffectHandler : MonoBehaviour
    {
        /// <summary>
        /// Tries to apply an effect to our handler
        /// Notifies when a new effect is applied
        /// Applies effects if the level or duration is greater than the current level or duration of an applied effect.  Level > Duration
        /// </summary>
        /// <param name="effect"></param>
        public void TryApply(IEffect effect)
        {
            
        }
    }
}