using Sandbox;
using Sandbox.Internal;

namespace Ian.Usables.Experimental;

public sealed class MacManager : Component, Component.INetworkSpawn, Component.IPressable
{
	[Property] public Rigidbody Rigidbody { get; set; }
	[Property] public Collider UseCollider { get; set; }
	[Property] public PanelComponent ScreenPanel { get; set; }
	[Property] public Mac128k MacPanel { get; set; }
	//[Property] public WorldInputClicker Clicker { get; set; }

	public bool isFocused { get; set; } = false;
	[Property] public string sysVer { get; set; } = "System+1.0";

	public void OnNetworkSpawn( Connection _ ) => Network.AssignOwnership( Rpc.Caller );

	protected override void OnAwake()
	{
		ScreenPanel.Enabled = true;

		Log.Info( "Attempting to start Macintosh with System Version: " + sysVer );
		MacPanel.Url = ("https://infinitemac.org/embed?disk=" + sysVer + "&infinite_hd=true&machine=Mac+128K&screen_scale");
	}
	public bool Press( IPressable.Event e )
	{
		OnUse();
		return true;
	}
	[Rpc.Broadcast]
	public void OnUse()
	{
		if ( isFocused )
		{
			isFocused = false;
			//Clicker.Enabled = false;

			//return control to player pawn			
		}
		else
		{
			isFocused = true;
			//Clicker.Enabled = true;
		}	
	}

	[ConCmd( "macintosh_sysver", Help = "Changes the System Version running on the Macintosh (ex: System+1.0 [1.0-3.3 excluding 2.2-2.9, and 3.1])" )]
	public void SysVer(string sysInput)
	{
		sysVer = sysInput;

		Log.Info( "Attempting to load System Version: " + sysVer );
		MacPanel.Url = ("https://infinitemac.org/embed?disk=" + sysVer + "&infinite_hd=true&machine=Mac+128K&screen_scale");
	}

	[ConCmd( "macintosh_reload", Help = "Reloads the webpanel on the Macintosh." )]
	public void MacReload()
	{
		MacPanel.Url = ("https://infinitemac.org/embed?disk=" + sysVer + "&infinite_hd=true&machine=Mac+128K&screen_scale");
	}
}
