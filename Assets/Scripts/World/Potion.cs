using System;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace World
{
    [SelectionBase]
    public class Potion : Prop, IDamagable
    {
        private IEffect _effect;
        
        private float _previousSpeed;
        
        [SerializeField] private float breakForce = -25; // This number should be squared manually so 10 --> 100.
        [SerializeField] private EffectCloud cloud;
        
        public void InitializeEffect(IEffect effect)
        {
            _effect = effect;
            print("Initialized Potion");
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            //While using SqrMagnitude is logically faster, the difference is very minor.
            Vector3 velocity = Rb.linearVelocity;
            float speed = velocity.sqrMagnitude;
            
            //If it's negative, then we've suddenly slowed down
            if (speed - _previousSpeed < breakForce)
            {
                if(Physics.OverlapSphere(transform.position, 0.2f, StaticUtility.GroundLayers).Length > 2)
                    Break(velocity);
            }

            _previousSpeed = speed;
        }

        public void TakeDamage(float amount)
        {
            Vector3 dir = Vector3.up;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
                dir = hit.normal;
            Break(dir);
        }

        public void TakeDamage(float amount, Vector3 force)
        {
            Break(-force);
        }


        private void Break(Vector3 direction)
        {
            Instantiate(cloud, transform.position, Quaternion.LookRotation(direction));
            Destroy(gameObject);
        }
    }
}
