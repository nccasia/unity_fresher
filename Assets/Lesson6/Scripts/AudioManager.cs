using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource AudioSource;
        public AudioSource SoundSource;
        public SoundList SoundList;

        public void PlaySound()
        {
            SoundSource.Play();
        }
        public void ChangeSound(AudioClip music)
        {
            if (AudioSource.clip.name == music.name)
            {
                return;
            }
            AudioSource.Stop();
            AudioSource.clip = music;
            AudioSource.Play();
        }
        public void PlayAudioClip(string name)
        {
            AudioClip clip = SoundList.getAudioClip(name);
            if (clip == null)
            {
                return;
            }
            
            if (AudioSource != null && AudioSource.clip != null)
            {
                if(AudioSource.clip.name == clip.name)
                {
                    return;
                }  
            }
            AudioSource.Stop();
            AudioSource.clip = clip;            
            AudioSource.Play();
        }
        public void StopMusic()
        {
            AudioSource.clip = null;
            AudioSource.Stop();
        }
        public void TurnOnOffMusic(bool isOn)
        {
            AudioSource.mute = !isOn;
        }

        public void TurnOnOffSound(bool isOn)
        {
            SoundSource.mute = !isOn;
        }
    }
}
