using Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Effects
{
    public class EffectCloud : MonoBehaviour
    {
        private IEffect _effect;

        //Only called once;
        // ReSharper disable Unity.PerformanceAnalysis
        public void Initialize([NotNull] IEffect effect)
        {
            #if UNITY_EDITOR
            if (_effect != null)
            {
                Debug.LogWarning("Trying to double initialize a potion");
                return;
            }
            #endif
            _effect = effect;
            ParticleSystem system = GetComponent<ParticleSystem>();

            var main = system.main;
            main.startColor = effect.GetColor();
            main.duration = effect.GetDuration();
        }

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.attachedRigidbody;
            if (rb && rb.TryGetComponent(out EffectHandler handler))
            {
                handler.TryApply(_effect);
            }
        }
    }
}
