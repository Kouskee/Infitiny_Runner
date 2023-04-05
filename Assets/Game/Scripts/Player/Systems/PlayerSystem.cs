using Game.ECS;
using Game.Platforms.Data;
using Game.Player.Components;
using UnityEngine;

namespace Game.Player.Systems
{
    public class PlayerSystem : RunMono, ISingleMono
    {
        private Vector2 _position;
        private PlayerComponent _component;
        
        public PlayerSystem(PlayerComponent component)
        {
            _component = component;
        }

        public void Start()
        {
            _component.InputSystem.OnJump += OnChosenDirection;
            var count = 0;
            while (!DefinitionStartPosition(count))
            {
                count++;
            }
            _component.MoveSystem.Start(_position);
        }
        
        private bool DefinitionStartPosition(int y)
        {
            for (int x = 0; x < _component.GridComponent.Grid[y].Length; x++)
            {
                if(_component.GridComponent.Grid[y][x].TypeCell != TypeCell.Platform) continue;
                
                _position = new Vector2(x, y);
                return true;
            }

            return false;
        }
        
        private void OnChosenDirection(Vector2 direction)
        {
            if(direction == Vector2.zero) return;
            Debug.Log(direction);
            Debug.Log(Mathf.RoundToInt(direction.x) +" "+ Mathf.RoundToInt(direction.y));
        }

        public override void Update()
        {
            
        }

        public override void Stop()
        {
            _component.InputSystem.OnJump -= OnChosenDirection;
        }

        public override void Continue()
        {
            _component.InputSystem.OnJump += OnChosenDirection;
        }

        public void Destroy()
        {
            _component.InputSystem.OnJump -= OnChosenDirection;
        }
    }
}