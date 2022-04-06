using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : NNEvents.NNEventActor<PlayerData, EnemyData>
{
  [SerializeField] private int playerHp;
  [SerializeField] private int attackValue;
  [SerializeField] private Text playerHpText;


  	private Animator _animator;
  	private bool isPlay;

	private new void Awake()
  {
    playerHpText.text = $"Player HP:{playerHp}";
    _animator = GetComponent<Animator>();
  }

	protected override void OnNNEvent(EnemyData e)
  {

    
      playerHp -= e.AttackValue;
      isPlay = e.Dead;
      _animator.SetTrigger("GetHit");
	  playerHpText.text = $"Player HP:{playerHp}";

      if (playerHp <= 0)
      {
	      _animator.SetBool("Dead", true);
	      PlayerData p = new PlayerData();
	      p.AttackValue = 0;
	      p.Dead = true;
	      PublishData(p);
      }
    


  }
   void Start()
  {
    Initialization();
  }


	private new void Update()
  {

    if (Input.GetKeyDown(KeyCode.A) && !isPlay)
    {
	    Debug.Log("Attack by Player");
	    _animator.SetTrigger("Attack");
	    PlayerData p = new PlayerData();
	    p.AttackValue = 3;
	    p.Dead = false;
	    PublishData(p);
    }

  }
}
