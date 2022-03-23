using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer;

namespace NNEvents
{
  public class NNEventEmitter<P> : MonoBehaviour
  {
    [Inject] protected IPublisher<P> Pub { get; set; }
    protected IDisposable _disposable;


    protected void Awake()
    {
    }


    void Start()
    {
      Initialization();
    }

    protected void Initialization()
    {
      var d = DisposableBag.CreateBuilder();
      _disposable = d.Build();
    }

    protected void Update()
    {
    }

    protected void EmitData(P data)
    {
      Pub.Publish(data);
    }

    protected void OnDestroy()
    {
      _disposable?.Dispose();
    }
  }

}