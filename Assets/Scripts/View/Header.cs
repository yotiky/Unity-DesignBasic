using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample1
{
    public class Header : MonoBehaviour
    {
        public UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public UniTask InvokeOnUpdate()
        {
            return UniTask.CompletedTask;
        }
    }
}