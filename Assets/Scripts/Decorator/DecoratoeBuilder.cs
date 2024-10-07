using System.Globalization;
using Effects;
using Interfaces;
using UnityEngine;

namespace Decorator
{
    public class DecoratoeBuilder : MonoBehaviour
    {
        private static readonly int Color1 = Shader.PropertyToID("_Main");
        private MundaneEffect demo;
        private Material meshRenderer;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            demo = new MundaneEffect();
            meshRenderer = transform.GetChild(2).GetComponent<MeshRenderer>().material;
        }

        [ContextMenu("Test 1")]
        void Test1()
        {
            demo.PushEffect(new HairyEffect());
               
            print("Test 1");
            print(demo.GetDescription());
            print(demo.GetCost().ToString(CultureInfo.InvariantCulture));
            meshRenderer.SetColor(Color1, demo.GetEffectColor());
        }
        [ContextMenu("Test 2")]
        void Test2()
        {
            demo.PushEffect(new ShrinkingEffect());
            print("Test 2");
            print(demo.GetDescription());
            print(demo.GetCost().ToString(CultureInfo.InvariantCulture));
            meshRenderer.SetColor(Color1, demo.GetEffectColor());
        }
    }
}
