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
            await deckTab.Initialize();
            await questTab.Initialize();

            await homePane.Initialize(network);
            await deckPane.Initialize(network);
            await questPane.Initialize(network);

            homeTab.OnSelected
                .Subscribe(_ =>
                {
                    homePane.Show();
                    deckPane.Hide();
                    questPane.Hide();
                })
                .AddTo(this);
            deckTab.OnSelected
                .Subscribe(_ =>
                {
                    homePane.Hide();
                    deckPane.Show();
                    questPane.Hide();
                })
                .AddTo(this);
            questTab.OnSelected
                .Subscribe(_ =>
                {
                    homePane.Hide();
                    deckPane.Hide();
                    questPane.Show();
                })
                .AddTo(this);

            homePane.OnNewsOpened
                .Subscribe(_ => Debug.Log("OnNewsOpened"))
                .AddTo(this);
            homePane.OnGiftOpened
                .Subscribe(_ => Debug.Log("OnGiftOpened"))
                .AddTo(this);
            deckPane.OnRenamed
                .Subscribe(_ => Debug.Log("OnRenamed"))
                .AddTo(this);
            deckPane.OnEdited
                .Subscribe(_ => Debug.Log("OnEdited"))
                .AddTo(this);
            questPane.OnQuestStarted
                .Subscribe(_ => Debug.Log("OnQuestStarted"))
                .AddTo(this);
            questPane.OnStoryPlayed
                .Subscribe(_ => Debug.Log("OnStoryPlayed"))
                .AddTo(this);

            homePane.Show();
            deckPane.Hide();
            questPane.Hide();
        }

        public async UniTask InvokeOnUpdate()
        {
            await homeTab.InvokeOnUpdate();
            await deckTab.InvokeOnUpdate();
            await questTab.InvokeOnUpdate();

            await homePane.InvokeOnUpdate();
            await deckPane.InvokeOnUpdate();
            await questPane.InvokeOnUpdate();
        }
    }
}