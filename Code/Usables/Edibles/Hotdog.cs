using Sandbox;

namespace Ian.Usables.Edibles;

[Title( "Hotdog" ), Icon( "local_dining" ), Category( "Usables" )]
public sealed class Hotdog : BaseUsable
{
	[Property]
	public SoundEvent UseSound { get; set; }

	public override void OnUse()
	{
		Sound.Play(UseSound, WorldPosition);
		Purge();
		base.OnUse();
	}

	public void Purge()
	{
		if ( !IsProxy )
			GameObject.Destroy();
	}
}
