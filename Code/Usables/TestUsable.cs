using Sandbox;

namespace Ian.Usables.Experimental;

[Title( "Color Cube" ), Icon( "deployed_code" ), Category( "Usables" )]
public sealed class UsableCube : BaseUsable
{
	[Property]
	public Color[] Colors { get; set; }

	[Property]
	public SoundEvent UseSound { get; set; }

	public override void OnUse()
	{
		ColorSwitch();
		Sound.Play(UseSound, WorldPosition);
		base.OnUse();
	}

	public void ColorSwitch()
	{
		ModelRenderer.Tint = Colors[Game.Random.Int( Colors.Length - 1 )];
	}
}
