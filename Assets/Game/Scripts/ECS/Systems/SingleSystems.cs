using System.Collections.Generic;

namespace Game.ECS
{
    public class SingleSystems
    {
        private readonly List<ISingleMono> _monos = new List<ISingleMono>();

        public SingleSystems(){}

        public void Add(ISingleMono mono)
        {
            _monos.Add(mono);
        }
        
        public void Start()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Start();
            }
        }
        
        public void Destroy()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Destroy();
            }
            _monos.Clear();
        }
    }
}