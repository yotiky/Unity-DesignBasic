using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Sample1
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private DeckPane deckPane;


        void Start()
        {
        }

        private CompositeDisposable disposables = new CompositeDisposable();
        private void UniRxSample()
        {
            deckPane.OnEdited
                .Subscribe(_ =>
                {
                })
                .AddTo(this);

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                })
                .AddTo(this);

            Observable.IntervalFrame(30)
                .Subscribe(_ =>
                {
                })
                .AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => CanInvoke何かの処理())
                .Subscribe(_ =>
                {
                })
                .AddTo(disposables);
        }

        void Update()
        {
            if (CanInvoke何かの処理())
            {
                // 処理A
            }
            if (IsElapsedある時間())
            {
                // 処理B
            }
            if (IsOver何かのカウンター())
            {
                // 処理C
            }
        }

        public void Clear()
        {
            disposables.Clear();
        }

        private bool CanInvoke何かの処理() => false;
        private bool IsElapsedある時間() => false;
        private bool IsOver何かのカウンター() => false;



        Guid guid;
        public Sample()
        {
            guid = Guid.NewGuid();
            Debug.Log($"Sample のコンストラクタ. GUID:{guid}");
        }
        ~Sample()
        {
            Debug.Log($"Sample のデストクラタ. GUID:{guid}");
        }
    }
}