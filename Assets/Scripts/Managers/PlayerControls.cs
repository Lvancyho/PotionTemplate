using Characters;
using UnityEngine;

namespace Managers
{
    public static class PlayerControls
    {
        private static Controls _controls;
        private static Player _player;

        public static void Init(Player player)
        {
            _controls = new Controls();
            
            
            _player = player;
            
            _controls.Player.Move.performed += context => _player.PlayerMovementComponent.Move(context.ReadValue<Vector2>());
            _controls.Player.Look.performed += context => _player.PlayerMovementComponent.Look(context.ReadValue<Vector2>());
            _controls.Player.Jump.performed += _ => _player.PlayerMovementComponent.Jump();
            
            _controls.Player.Interact.performed += context => _player.PlayerInteractionComponent.SetInteractionState(context.ReadValueAsButton());
            
            
        }

        public static void EnableGameControls()
        {
            _controls.Player.Enable();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}