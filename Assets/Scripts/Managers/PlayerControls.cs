using Characters;
using DrawingSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public static class PlayerControls
    {
        private static readonly Controls Controls = new Controls();
        private static Player _player;
        private static CanvasController _canvas;

        public static void InitPlayer(Player player)
        {
            if (_player == null)
            {
                Controls.Player.Move.performed += context =>
                    _player.PlayerMovementComponent.Move(context.ReadValue<Vector2>());
                Controls.Player.Look.performed += context =>
                    _player.PlayerMovementComponent.Look(context.ReadValue<Vector2>());
                Controls.Player.Jump.performed += _ => _player.PlayerMovementComponent.Jump();
                Controls.Player.Interact.performed += context =>
                    _player.PlayerInteractionComponent.SetInteractionState(context.ReadValueAsButton());
            }

            _player = player;
        }

        public static void EnableGameControls()
        {
            Controls.Player.Enable();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public static void DrawingScreen(CanvasController canvas)
        {
            if (_canvas == null)
            {
                Controls.Drawing.Primary.started += ctx => _canvas.BeginPrimary(ctx.ReadValue<Vector2>());
                Controls.Drawing.Primary.performed += ctx => _canvas.UpdatePrimary(ctx.ReadValue<Vector2>());
                Controls.Drawing.Primary.canceled += ctx => _canvas.EndPrimary(ctx.ReadValue<Vector2>());

                Controls.Drawing.Undo.performed += ctx => _canvas.Undo();
                Controls.Drawing.Redo.performed += ctx => _canvas.Redo();

                Controls.Drawing.Undo.performed += ctx => { if (ctx.control.IsPressed()) _canvas.Undo(); };
                Controls.Drawing.Redo.performed += ctx => { if (ctx.control.IsPressed()) _canvas.Redo(); };
                Controls.Drawing.Clear.performed += ctx => { if (ctx.control.IsPressed()) _canvas.ClearCanvas(); };

            }
            _canvas = canvas;
        }

        public static void EnterDrawing()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Controls.Player.Disable();
            Controls.Drawing.Enable();
        }
    }
}