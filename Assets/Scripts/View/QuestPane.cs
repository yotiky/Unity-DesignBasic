using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample1
{
    public class QuestPane : MonoBehaviour
    {
        [SerializeField] private Button startLatestButton;
        [SerializeField] private Button playStoryButton;

        private Network network;

        private readonly Subject<int> onQuestStarted = new Subject<int>();
        public IObservable<int> OnQuestStarted => onQuestStarted;

        private readonly Subject<Unit> onStoryPlayed = new Subject<Unit>();
        public IObservable<Unit> OnStoryPlayed => onStoryPlayed;

        public async UniTask Initialize(Network network)
        {
            this.network = network;

            var latestQuestId = await network.API.GetLatestQuestId();

            startLatestButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onQuestStarted.OnNext(latestQuestId);
                })
                .AddTo(this);

            playStoryButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onStoryPlayed.OnNext(Unit.Default);
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