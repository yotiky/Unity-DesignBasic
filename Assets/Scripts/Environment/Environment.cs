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

            var bgm = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bgm.name = "BGM";
            DontDestroyOnLoad(bgm);

            var se = GameObject.CreatePrimitive(PrimitiveType.Cube);
            se.name = "SE";
            DontDestroyOnLoad(se);
        }

        public async UniTask InvokeOnUpdate()
        {
            await stage.InvokeOnUpdate();
        }
    }
}