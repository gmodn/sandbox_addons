using System;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.Internal;

namespace Ian.Usables.Props;

[Title( "Minecraft Sign Manager" ), Icon( "table_sign" ), Category( "Usables" )]
public class MCSignManager : BaseUsable
{
	//References for Text objects
	[Property] TextRenderer Line1Ref { get; set; }
	[Property] TextRenderer Line2Ref { get; set; }
	[Property] TextRenderer Line3Ref { get; set; }
	[Property] TextRenderer Line4Ref { get; set; }

	//Strings for modifying the text
	public string Line1 { get; set; } = "Line 1";
	public string Line2 { get; set; } = "Line 2";
	public string Line3 { get; set; } = "Line 3";
	public string Line4 { get; set; } = "Line 4";


	public override void OnUse()
	{
		base.OnUse();
		RefreshText();
		// make this open a panel that lets you motify the text
	}

	public void RefreshText()
	{
		Log.Info( "MCSignManager: Sign with the ID " + this.GameObject.Id + " has been updated!" );
		Line1Ref.Text = Line1;
		Line2Ref.Text = Line2;
		Line3Ref.Text = Line3;
		Line4Ref.Text = Line4;
	}

	static void SetCmd()
	{

	}
}
