

using System;
using MessagePipe;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;


public class Enemy : NNEvents.NNEventActor<EnemyData, PlayerData>, IStartable
{
  [SerializeField] private int enemyHp;
  [SerializeField] private Text enemyHpText;
  private bool _isPlay;


  private Animator _animator;


  private new void Awake()
  {
    enemyHpText.text = $"Enemy HP:{enemyHp}";
    _animator = GetComponent<Animator>();
  }

  protected override void OnNNEvent(PlayerData e)
  {


    enemyHp -= e.AttackValue;
    _isPlay = e.Dead;
    _animator.SetTrigger("GetHit");
    enemyHpText.text = $"Enemy HP:{enemyHp}";

    if (enemyHp <= 0)
    {
      EnemyData d = new EnemyData();
      d.AttackValue = 0;
      d.Dead = true;
      PublishData(d);
      _animator.SetBool("Dead", true);
    }
  }

  public void Start()
  {
    Initialization();



    Observable.Interval(TimeSpan.FromSeconds(5f))
      .Where(_ => !_isPlay)
      .Subscribe(_ =>
      {
        Debug.Log("Attacked by Enemy");
        _animator.SetTrigger("Attack");
        EnemyData d = new EnemyData();
        d.AttackValue = 5;
        d.Dead = false;
        PublishData(d);
      }).AddTo(this);
  }




}
