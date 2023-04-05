using Game.ECS;
using Game.Player.Components;
using UnityEngine;

namespace Game.Player.Systems
{
    public class PlayerMoveSystem : RunMono
    {
        private readonly PlayerMoveComponent _comp;

        public PlayerMoveSystem(PlayerMoveComponent component)
        {
            _comp = component;
            _comp.Transform.gameObject.SetActive(true);
        }

        public void Start(Vector2 pos)
        {
            _comp.Transform.position = new Vector3(pos.x * 20, _comp.Transform.position.y, pos.y * 20);
        }
        
        public override void FixedUpdate()
        {
            
        }

        public override void Stop()
        {
            
        }

        public override void Continue()
        {
            
        }
    }
}