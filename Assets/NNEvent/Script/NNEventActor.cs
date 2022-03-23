using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MessagePipe;
using VContainer;

namespace NNEvents
{
  public class NNEventActor<P, E> : MonoBehaviour
  {

    [Inject] protected ISubscriber<E> Sub { get; set; }
    [Inject] protected IPublisher<P> Pub { get; set; }
    protected IDisposable _disposable;


    protected void Awake()
    {
    }

    protected virtual void OnNNEvent(E e)
    {
    }
    void Start()

    {
      Initialization();
    }

    protected void Initialization()
    {
      var d = DisposableBag.CreateBuilder();
      Sub.Subscribe(OnNNEvent).AddTo(d);

      _disposable = d.Build();
    }

    protected void Update()
    {

    }

    protected void PublishData(P data)
    {
      Pub.Publish(data);
    }

    protected void OnDestroy()
    {
      _disposable?.Dispose();
    }
  }

}