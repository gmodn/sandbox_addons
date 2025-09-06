using Sandbox;
using Sandbox.UI;


// This is a WIP and that is why it's not hooked up to the MacManager yet. I need to figure out how I would get the reference of the camera being hooked up to the player controller back. -e&
namespace Ian.Usables.Experimental;
public sealed class WorldInputClicker : Component
{
	[Property, InputAction]
	public string LeftMouseAction { get; set; } = "Attack1";

	[Property, InputAction]
	public string RightMouseAction { get; set; } = "Attack2";

	private Sandbox.UI.WorldInput worldInput = new Sandbox.UI.WorldInput();

	public Panel Hovered => worldInput.Hovered;

	protected override void OnEnabled()
	{
		worldInput.Enabled = true;
	}

	protected override void OnDisabled()
	{
		worldInput.Enabled = false;
	}

	protected override void OnUpdate()
	{
		if ( worldInput.Enabled )
		{
			worldInput.Ray = Scene.Camera.ScreenPixelToRay( Mouse.Position );
			worldInput.MouseLeftPressed = Input.Down( LeftMouseAction );
			worldInput.MouseRightPressed = Input.Down( RightMouseAction );
			worldInput.MouseWheel = -Input.MouseWheel;
			Mouse.Visibility = MouseVisibility.Visible;
		}
		else
		{

		}
	}
}
