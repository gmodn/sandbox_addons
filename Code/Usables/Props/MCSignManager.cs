using System;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.Internal;

namespace Ian.Usables.Props;

[Title( "Minecraft Sign Manager" ), Icon( "table_sign" ), Category( "Usables" )]
public class MCSignManager : BaseUsable
{
	// General
	[Property] public SoundEvent UseSound { get; set; }

	// References for Text objects
	[Property] TextRenderer Line1Ref { get; set; }
	[Property] TextRenderer Line2Ref { get; set; }
	[Property] TextRenderer Line3Ref { get; set; }
	[Property] TextRenderer Line4Ref { get; set; }

	public override void OnUse()
	{
		base.OnUse();
		Sound.Play( UseSound );
		RefreshText();
		Log.Info( "Attempted to use the sign!" );
	}

	public void RefreshText()
	{
		// pull cookies
		var Line1cookie = Game.Cookies.GetString( "mcsignline1", "Line1" );
		var Line2cookie = Game.Cookies.GetString( "mcsignline2", "Line2" );
		var Line3cookie = Game.Cookies.GetString( "mcsignline3", "Line3" );
		var Line4cookie = Game.Cookies.GetString( "mcsignline4", "Line4" );

		Line1Ref.Text = Line1cookie;
		Line2Ref.Text = Line2cookie;
		Line3Ref.Text = Line3cookie;
		Line4Ref.Text = Line4cookie;
	}

	[ConCmd( "mcsign_set", Help = "Set text on the Minecraft Sign" )]
	public static async Task SetText( string Line1, string Line2, string Line3, string Line4 )
	{
		Game.Cookies.Set( "mcsignline1", Line1 );
		Game.Cookies.Set( "mcsignline2", Line2 );
		Game.Cookies.Set( "mcsignline3", Line3 );
		Game.Cookies.Set( "mcsignline4", Line4 );

		Log.Info( "Strings set. Press use on the sign to update it!" );
	}
}
