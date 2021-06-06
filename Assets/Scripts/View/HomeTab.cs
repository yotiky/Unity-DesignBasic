using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample1
{
    public class HomeTab : MonoBehaviour
    {
        [SerializeField] private Text tabLabel;
        [SerializeField] private Button tabButton;

        private readonly Subject<Unit> onSelected = new Subject<Unit>();
        public IObservable<Unit> OnSelected => onSelected;

        public UniTask Initialize()
        {
            tabLabel.text = "Home";

            tabButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onSelected.OnNext(Unit.Default);
                })
                .AddTo(this);

            return UniTask.CompletedTask;
        }

        public UniTask InvokeOnUpdate()
        {
            return UniTask.CompletedTask;
        }
    }
}