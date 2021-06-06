using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Sample1
{
    public class Contents : MonoBehaviour
    {
        [SerializeField] private HomeTab homeTab;
        [SerializeField] private HomePane homePane;
        [SerializeField] private DeckTab deckTab;
        [SerializeField] private DeckPane deckPane;
        [SerializeField] private QuestTab questTab;
        [SerializeField] private QuestPane questPane;

        private Network network;

        public async UniTask Initialize(Network network)
        {
            this.network = network;

            await homeTab.Initialize();
            await homePane.Initialize(network);
            await deckTab.Initialize();
            await deckPane.Initialize(network);
            await questTab.Initialize();
            await questPane.Initialize(network);

            deckTab.OnSelected
                .Subscribe(_ =>
                {
                    // 選択された時の処理
                })
                .AddTo(this);
        }

        public async UniTask InvokeOnUpdate()
        {
            await homeTab.InvokeOnUpdate();
            await homePane.InvokeOnUpdate();
            await deckTab.InvokeOnUpdate();
            await deckPane.InvokeOnUpdate();
            await questTab.InvokeOnUpdate();
            await questPane.InvokeOnUpdate();
        }
    }
}