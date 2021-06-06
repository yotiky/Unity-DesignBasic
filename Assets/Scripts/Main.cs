using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample1
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Environment environment;
        [SerializeField] private Navigation navigation;
        [SerializeField] private Network network;
        [SerializeField] private SampleView sampleView;

        async void Start()
        {
            await player.Initialize();
            await environment.Initialize();
            await navigation.Initialize();
            await network.Initialize();
            await sampleView.Initialize(network);
        }

        async void Update()
        {
            await player.InvokeOnUpdate();
            await environment.InvokeOnUpdate();
            await navigation.InvokeOnUpdate();
            await network.InvokeOnUpdate();
            await sampleView.InvokeOnUpdate();
        }
    }
}