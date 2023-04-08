using System.Threading.Tasks;
using Game.ECS;
using Game.Player.Components;
using UnityEngine;

namespace Game.Player.Systems
{
    public class PlayerMoveSystem : RunMono
    {
        private readonly PlayerMoveComponent _comp;
        public bool CanMove { get; private set; }

        public PlayerMoveSystem(PlayerMoveComponent component)
        {
            _comp = component;
            _comp.Transform.gameObject.SetActive(true);
        }

        public async void MoveTo(Vector2 pos)
        {
            CanMove = false;
            var targetPos = new Vector3(pos.x * 20, _comp.Transform.position.y, pos.y * 20);
            while (_comp.Transform.position != targetPos)
            {
                _comp.Transform.position = Vector3.MoveTowards(
                    _comp.Transform.position, 
                    targetPos,
                    _comp.Data.Speed * Time.deltaTime);
                await Task.Yield();
            }
 
            CanMove = true;
        }
    }
}