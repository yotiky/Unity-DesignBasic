using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample1
{
    public class Network : MonoBehaviour
    {
        private readonly Api api = new Api();
        public Api API => api;

        public UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public UniTask InvokeOnUpdate()
        {
            return UniTask.CompletedTask;
        }
    }

    public class Api
    {
        public async UniTask<int> GetLatestQuestId()
        {
            return 1;
        }

        public async UniTask<Deck> GetCurrentDeck()
        {
            return new Deck()
            {
                Name = "Deck name",
                Cards = new string[] { "Card1", "Card2", "Card3" },
            };
        }

        public async UniTask<int> GetNewsCount()
        {
            return 1;
        }

        public async UniTask<int> GetGiftCount()
        {
            return 1;
        }
    }
    public class Deck
    {
        public string Name { get; set; }
        public string[] Cards { get; set; }
    }
}