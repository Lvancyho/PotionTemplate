using System.Text;
using Interfaces;
using UnityEngine;

namespace Effects
{
    public class BasicEffect : IEffect
    {
        public StringBuilder GetDetails()
        {
            return new StringBuilder();
        }

        public Color GetColor()
        {
            return Color.white;
        }

        public float GetDuration()
        {
            return 0;
        }

        public float GetStrength()
        {
            return 1;
        }
    }
}
