using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Sample1
{
    public class Stage : MonoBehaviour
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