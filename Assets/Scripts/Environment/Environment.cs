using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample1
{
    public class Environment : MonoBehaviour
    {
        //public static Environment Instance;

        [SerializeField] private Stage stage;

        public async UniTask Initialize()
        {
            await stage.Initialize();

            var bgm = new GameObject("BGM");
            DontDestroyOnLoad(bgm);

            var se = new GameObject("SE");
            DontDestroyOnLoad(se);
        }

        public async UniTask InvokeOnUpdate()
        {
            await stage.InvokeOnUpdate();
        }
    }
}