using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "NewAudioPreset", menuName = "Audio/Audio Preset SO")]
    public class AudioPresetSO : ScriptableObject
    {
        public AudioClip[] HitSound;
        public AudioClip MovingSound;
    }
}