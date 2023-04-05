using Game.ECS;
using UnityEngine;

namespace Game.Player.Components
{
    public struct PlayerEffectsComponent
    {
        public PlayerEffectsComponent(Transform target)
        {
            Target = target;
        }
        
        public Transform Target { get;}
    }
}