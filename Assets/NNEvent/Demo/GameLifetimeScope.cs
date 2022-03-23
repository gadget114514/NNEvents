using MessagePipe;
using NNEvents;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
	protected override void Configure(IContainerBuilder builder)
	{
		Debug.Log("Configure");
		var options = builder.RegisterMessagePipe();
		builder.RegisterMessageBroker<PlayerData>(options);
		builder.RegisterMessageBroker<EnemyData>(options);

	}
}