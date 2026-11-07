using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

public class HitSource : MonoBehaviour
{
    private const float Multiplier = 0.4f;
    
    [SerializeField] private AudioSource _audioSource;
    private IObjectPool<HitSource> _pool;

    public void SetPool(IObjectPool<HitSource> pool)
    {
        _pool = pool;
    }

    public void Use(AudioClip clip, float volume, Vector3 position)
    {
        transform.position = position;
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(clip, volume * Multiplier);
        
        BackToPool(clip.length).Forget();
    }

    private async UniTaskVoid BackToPool(float audioLenght)
    {
        await UniTask.WaitForSeconds(audioLenght);
        _pool.Release(this);
    }
}
