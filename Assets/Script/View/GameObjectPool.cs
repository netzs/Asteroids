using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.View
{
    public class GameObjectPool
    {
        private Dictionary<string, Stack<GameObject>> _pool = new Dictionary<string, Stack<GameObject>>();

        public GameObject Get(GameObject prefab)
        {
            if (_pool.TryGetValue(prefab.name, out var lst) && lst.Count > 0)
            {
                var obj = lst.Pop();
                obj.SetActive(true);
                return obj;
            }

            var pr = Object.Instantiate(prefab);
            pr.name = prefab.name;
            return pr;
        }

        public void Release(GameObject obj)
        {
            obj.SetActive(false);
            if (_pool.TryGetValue(obj.name, out var lst))
            {
                lst.Push(obj);
            }
            else
            {
                _pool.Add(obj.name, new Stack<GameObject>(new[] {obj}));
            }
        }
    }
}