
using UnityEngine;
using Commons;


namespace SFXServices
{
    public class SFXService : GenericMonoSingleton<SFXService>
    {

        public AudioSource audioSource1;
        public AudioSource audioSource2;
        public AudioSource UITrack;

        public void PlaySoundAtTrack1(AudioClip audioClip, float volume, int priority, bool overrideSound = true)
        {
            if ((audioSource1.clip != audioClip) || (audioSource1.isPlaying && overrideSound))
            {
                audioSource1.clip = audioClip;
                audioSource1.volume = volume;
                audioSource1.priority = priority;
                audioSource1.Play();

            }
            else return;
        }
        public void PlaySoundAtTrack2(AudioClip audioClip, float volume, int priority, bool overrideSound = true)
        {
            if ((audioSource2.clip != audioClip) || (audioSource2.isPlaying && overrideSound))
            {
                audioSource2.clip = audioClip;
                audioSource2.volume = volume;
                audioSource2.priority = priority;
                audioSource2.Play();

            }
            else return;
        }
        public void PlayUITrack(AudioClip clip)
        {
            UITrack.clip = clip;

        }
        public void TurnOffSoundsExceptUI()
        {
            audioSource1.enabled = false;
            audioSource2.enabled = false;
        }
        public void ResetSounds()
        {
            audioSource1.enabled = true;
            audioSource2.enabled = true;
        }

    }
}
