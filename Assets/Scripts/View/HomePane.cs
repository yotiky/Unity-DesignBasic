using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample1
{
    public class HomePane : MonoBehaviour
    {
        [SerializeField] private Text newsCountText;
        [SerializeField] private Button newsButton;
        [SerializeField] private Text giftCountText;
        [SerializeField] private Button giftButton;

        private Network network;

        private readonly Subject<Unit> onNewsOpened = new Subject<Unit>();
        public IObservable<Unit> OnNewsOpened => onNewsOpened;

        private readonly Subject<Unit> onGiftOpened = new Subject<Unit>();
        public IObservable<Unit> OnGiftOpened => onGiftOpened;

        public async UniTask Initialize(Network network)
        {
            this.network = network;

            var newsCount = await network.API.GetNewsCount();
            var giftCount = await network.API.GetGiftCount();

            newsCountText.text = newsCount.ToString();
            giftCountText.text = giftCount.ToString();

            newsButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onNewsOpened.OnNext(Unit.Default);
                })
                .AddTo(this);

            giftButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onGiftOpened.OnNext(Unit.Default);
                })
                .AddTo(this);
        }

        public UniTask InvokeOnUpdate()
        {
            return UniTask.CompletedTask;
        }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}