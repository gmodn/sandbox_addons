using Sandbox;

namespace Ian.Usables.Tools;

[Title( "Lamp" ), Icon( "light" ), Category( "Usables" )]
public sealed class UsableLamp : BaseUsable
{
	[Property]
	public SpotLight spotLight { get; set; }
	
	[Property]
	public SpotLight innerLight { get; set; }

	[Property]
	public SoundEvent UseSound { get; set; }

	public bool isLampOn { get; set; } = true;

	public override void OnUse()
	{
		LightToggle();
		Sound.Play( UseSound, WorldPosition );
		base.OnUse();
	}

	public void LightToggle()
	{
		if ( !IsProxy )
		{
			if ( isLampOn )
			{
				spotLight.Enabled = false;
				innerLight.Enabled = false;
				isLampOn = false;
			}
			else
			{
				spotLight.Enabled = true;
				innerLight.Enabled = true;
				isLampOn = true;
			}
		}
	}
}
