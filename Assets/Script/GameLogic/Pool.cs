using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Asteroid.GameLogic
{
    public class Pool<T>  : AbstractPoolObject<T>
    {
        private int _ids;
        private readonly Dictionary<int, T> _objects = new Dictionary<int, T>();
        private readonly Dictionary<int, T> _newObjectPool = new Dictionary<int, T>();
        private readonly Dictionary<int, T> _removeObjectPool = new Dictionary<int, T>();


        public int Add(T obj)
        {
            _ids++;
            _newObjectPool.Add(_ids, obj);
            return _ids;
        }

        public void Del(int id)
        {
            if (_objects.TryGetValue(id, out var val))
            {
                _removeObjectPool.Add(id, val);
                _objects.Remove(id);
            }
            else
            {
                throw new Exception("Bad Remove object : " + id);
            }
        }


        public void ReleaseObject()
        {
            foreach (var item in _newObjectPool)
            {
                _objects.Add(item.Key, item.Value);
            }

            _newObjectPool.Clear();
            _removeObjectPool.Clear();
        }

        public void Reset()
        {
            _ids = 0;
            _objects.Clear();
            _newObjectPool.Clear();
            _removeObjectPool.Clear();
        }

        public Pool()
        {
            Objects = new ReadOnlyDictionary<int, T>(_objects);
            NewObjectPool = new ReadOnlyDictionary<int, T>(_newObjectPool);
            RemoveObjectPool = new ReadOnlyDictionary<int, T>(_removeObjectPool);
        }
    }


    public abstract class AbstractPoolObject<T>
    {
        public ReadOnlyDictionary<int, T> Objects;
        public ReadOnlyDictionary<int, T> NewObjectPool;
        public ReadOnlyDictionary<int, T> RemoveObjectPool;
    }
}