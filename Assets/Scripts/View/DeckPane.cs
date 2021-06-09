using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample1
{
    public class DeckPane : MonoBehaviour
    {
        [SerializeField] private Text deckNameText;
        [SerializeField] private Button renameButton;
        [SerializeField] private Button editButton;

        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject cardContainer;

        private Network network;

        private readonly Subject<Unit> onRenamed = new Subject<Unit>();
        public IObservable<Unit> OnRenamed => onRenamed;

        private readonly Subject<Unit> onEdited = new Subject<Unit>();
        public IObservable<Unit> OnEdited => onEdited;

        public async UniTask Initialize(Network network)
        {
            this.network = network;

            var deck = await network.API.GetCurrentDeck();

            deckNameText.text = deck.Name;
            foreach (var card in deck.Cards)
            {
                var go = Instantiate(cardPrefab, cardContainer.transform);
                go.name = card;
            }

            renameButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onRenamed.OnNext(Unit.Default);
                })
                .AddTo(this);

            editButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // クリック時の処理
                    onEdited.OnNext(Unit.Default);
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