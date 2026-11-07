using UnityEngine;
using UnityEngine.Pool;

public class HitSourcePoolManager : MonoBehaviour
{
    public static HitSourcePoolManager instance {get; private set;}
    [SerializeField] private HitSource _hitSourcePrefab;

    [SerializeField] private bool _collectionChek = true;
    [SerializeField] private int _defaultPoolSize = 10;
    [SerializeField] private int _maxPoolSize = 20;
    
    private IObjectPool<HitSource> _pool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            InitializePool();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializePool()
    {
        _pool = new ObjectPool<HitSource>(
            createFunc: CreateHitSource,
            actionOnGet: OnGetHitSource,
            actionOnRelease: OnReleaseHitSource,
            actionOnDestroy: OnDestroyHitSource,
            collectionCheck: _collectionChek,
            defaultCapacity: _defaultPoolSize,
            maxSize: _maxPoolSize
            );
    }

    public void Hit(AudioClip clip, float volume, Vector3 position)
    {
        HitSource hitSourceInstance = _pool.Get();
        
        hitSourceInstance.Use(clip, volume, position);
    }

    private HitSource CreateHitSource()
    {
        HitSource hitSourceInstance = Instantiate(_hitSourcePrefab);
        hitSourceInstance.SetPool(_pool);
        return hitSourceInstance;
    }

    private void OnGetHitSource(HitSource hitSourceInstance)
    {
        hitSourceInstance.gameObject.SetActive(true);
    }

    private void OnReleaseHitSource(HitSource hitSourceInstance)
    {
        hitSourceInstance.gameObject.SetActive(false);
    }

    private void OnDestroyHitSource(HitSource hitSourceInstance)
    {
        Destroy(hitSourceInstance.gameObject);
    }
}
