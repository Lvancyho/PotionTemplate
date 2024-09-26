using System.Text;
using Effects;
using UnityEngine;

namespace Interfaces
{
    public interface IEffect
    {
        //Show difference using string vs string builder
        public StringBuilder GetDetails();
        public Color GetColor();
        public float GetDuration();
        public float GetStrength();
    }
}
