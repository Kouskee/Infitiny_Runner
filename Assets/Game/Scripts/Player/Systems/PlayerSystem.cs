using Game.ECS;
using Game.Platforms.Data;
using Game.Player.Components;
using UnityEngine;

namespace Game.Player.Systems
{
    public class PlayerSystem : RunMono, ISingleMono
    {
        private const float TIME_TO_MOVE = 2;
        private float _timer = TIME_TO_MOVE;
        private bool _timerRunning;
        
        private Vector2Int _position;
        private PlayerComponent _cmp;
        
        public PlayerSystem(PlayerComponent cmp)
        {
            _cmp = cmp;
        }

        public void Start()
        {
            _cmp.InputSystem.OnJump += OnChosenDirection;
            var count = 0;
            while (!DefinitionStartPosition(count))
            {
                count++;
            }
            _cmp.MoveSystem.MoveTo(_position);
        }
        
        private bool DefinitionStartPosition(int y)
        {
            for (int x = 0; x < _cmp.GridComponent.Grid[y].Length; x++)
            {
                if(_cmp.GridComponent.Grid[y][x].TypeCell != TypeCell.Platform) continue;
                
                _position = new Vector2Int(x, y);
                return true;
            }

            return false;
        }
        
        private void OnChosenDirection(Vector2 direction)
        {
            if(direction == Vector2.zero || !_cmp.MoveSystem.CanMove) return;
            var newPosition = new Vector2Int(_position.x + Mathf.RoundToInt(direction.x), _position.y + Mathf.RoundToInt(direction.y));
            var cell = _cmp.GridComponent.GetCell(newPosition.x, newPosition.y);
            switch (cell.TypeCell)
            {
                case TypeCell.Platform:
                    Move(newPosition);
                    StopTimer();
                    break;
                case TypeCell.Wall:
                    break;
                case TypeCell.Null:
                    Move(newPosition);
                    _timerRunning = true;
                    break;
            }
        }

        private void Move(Vector2Int newPosition)
        {
            _cmp.MoveSystem.MoveTo(newPosition);
            _position = newPosition;
        }

        private void StopTimer()
        {
            _timerRunning = false;
            _timer = TIME_TO_MOVE;
        }

        public override void Update()
        {
            if (!_timerRunning) return;
            
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                Debug.Log(_timer);
            }
            else
            {
                Debug.Log("you already dead");
            }
        }

        public override void Stop()
        {
            _cmp.InputSystem.OnJump -= OnChosenDirection;
        }

        public override void Continue()
        {
            _cmp.InputSystem.OnJump += OnChosenDirection;
        }

        public void Destroy()
        {
            _cmp.InputSystem.OnJump -= OnChosenDirection;
        }
    }
}