using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private void Awake(){
        Instance= this;
    }
    class Pool
    {
        private List<GameObject> _inactive = new List<GameObject>();
        private GameObject _prefab;
        public Pool(GameObject prefab) {
            this._prefab = prefab;
        }
        public GameObject Spawn(Vector3 position, Quaternion rotation) {   
            GameObject obj;
            if (_inactive.Count ==0 ) {
                obj = Instantiate(_prefab, position, rotation);
                obj.name = _prefab.name;
                obj.transform. SetParent(Instance.transform) ;
            }
            else {
                obj = _inactive[_inactive.Count - 1];
                _inactive .RemoveAt(_inactive.Count - 1);
            }
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }
        public void Despawn(GameObject obj) {
            obj .SetActive(false);
            _inactive.Add(obj); 
        }
    }

    private Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();

    void Init(GameObject prefab) {
        if (prefab != null && _pools.ContainsKey(prefab.name)==false){
            _pools[prefab.name] = new Pool (prefab);
        }
    }

    public void Preload(GameObject prefab, int count) {
        Init (prefab);
        GameObject[] objs = new GameObject[count];
        for(int i=0; i < count; i++) {
           objs[i] = Spawn(prefab,Vector3.zero,Quaternion.identity);
           Despawn(objs[i]);
        }
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation) {
        Init (prefab);
        return _pools[prefab.name].Spawn(position, rotation);
    }

    public void Despawn(GameObject obj) {
    if (_pools.ContainsKey(obj.name)) {
        _pools[obj.name] .Despawn(obj);
    } 
    else {
        Destroy(obj);
        }
    }
}


