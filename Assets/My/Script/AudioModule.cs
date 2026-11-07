using SteamAudio;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(Rigidbody), typeof(AudioSource),typeof(SteamAudioSource))]
    public class AudioModule : MonoBehaviour
    {
        private const float SpeedThreshold = 3f;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioPresetSO _audioPreset;
        
        [SerializeField] private bool _disableMovingSound;

        private HitSourcePoolManager _poolManager;
        private ContactPoint contact;

        private void Start()
        {
            _audioSource.clip =  _audioPreset.MovingSound;
            _poolManager = HitSourcePoolManager.instance;
        }

        
        private void FixedUpdate()
        {
            if (_disableMovingSound) return;
            
            if (_rigidbody.linearVelocity.sqrMagnitude > SpeedThreshold && !_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            else if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            contact = collision.contacts[0];
            _poolManager.Hit(
                _audioPreset.HitSound[
                    Random.Range(0, _audioPreset.HitSound.Length)],
                collision.relativeVelocity.magnitude,
                contact.point
                );
        }
    }
}