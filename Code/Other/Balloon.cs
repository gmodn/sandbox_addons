using Sandbox;

namespace Ian.SandboxAddons;

public class Balloon : Component, Component.INetworkSpawn
{
	[Property] public Rigidbody Rigidbody { get; set; }
	[Property] public Collider Collider { get; set; }
	[Property] public ModelRenderer ModelRenderer { get; set; }

	private static float GravityScale => -0.2f;

	public void OnNetworkSpawn( Connection _ )
	{
		Network.AssignOwnership( Rpc.Caller );
		Rigidbody.PhysicsBody.GravityScale = GravityScale;
	}

	protected override void OnAwake()
	{
		Collider = GetComponent<Collider>();
	}
}
