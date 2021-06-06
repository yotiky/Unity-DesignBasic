using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample1
{
    public class SampleView : MonoBehaviour
    {
        [SerializeField] private Header header;
        [SerializeField] private Contents contents;
        [SerializeField] private Footer footer;

        public async UniTask Initialize(Network network)
        {
            await header.Initialize();
            await contents.Initialize(network);
            await footer.Initialize();
        }

        public async UniTask InvokeOnUpdate()
        {
            await header.InvokeOnUpdate();
            await contents.InvokeOnUpdate();
            await footer.InvokeOnUpdate();
        }
    }
}