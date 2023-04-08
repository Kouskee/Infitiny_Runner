using System;
using Game.ECS;
using UnityEngine;

namespace Game.Player.Systems
{
    public class PlayerInputSystem : ISingleMono
    {
        public Action<Vector2> OnJump;

        private Vector2 _direction;
        
        private readonly PlayerControl _action;
        
        public PlayerInputSystem()
        {
            _action = new PlayerControl();
        }
        
        public void Start()
        {
            _action.PlayerMap.Enable();
            _action.PlayerMap.Move.performed += context => _direction = context.ReadValue<Vector2>();
            _action.PlayerMap.Move.canceled += _ => _direction = Vector2.zero;
            _action.PlayerMap.Jump.started += context => OnJump?.Invoke(_direction);
        }
        
        public void Destroy() { }
    }
}