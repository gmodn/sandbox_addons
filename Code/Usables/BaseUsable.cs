using Sandbox;

namespace Ian.Usables;

public class BaseUsable : Component, Component.IPressable, Component.INetworkSpawn
{	
	[Property]
	public Collider Collider { get; set; }

	[Property]
	public ModelRenderer ModelRenderer { get; set; }

	public void OnNetworkSpawn( Connection _ ) => Network.AssignOwnership( Rpc.Caller );
	public bool Press( IPressable.Event e )
	{
		OnUse();
		return true;
	}

	protected override void OnAwake()
	{
		Collider = GetComponent<Collider>();
	}

	[Rpc.Broadcast]
	public virtual void OnUse()
	{
		// If the Usable is used, trigger this event.
	}
}
