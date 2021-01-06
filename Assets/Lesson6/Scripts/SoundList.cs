
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Audio
{
    [System.Serializable]
    public class SoundListTab
    {
        public string name;
        public AudioClip music;
    }
    public class SoundList : MonoBehaviour
    {
        public List<SoundListTab> soundList;

        public AudioClip getAudioClip(string name){
            SoundListTab soundListTab = this.soundList.Where(ev =>
                ev.name.ToUpper().Equals(name.ToUpper())
            ).FirstOrDefault();
            if (soundListTab == null)
            {
                return null;
            }
            return soundListTab.music;
        }
        
        public SoundListTab getSound(string name)
        {
            return this.soundList.Where(ev =>
                ev.name.ToUpper().Equals(name.ToUpper())
            ).FirstOrDefault();
        }
    }
}