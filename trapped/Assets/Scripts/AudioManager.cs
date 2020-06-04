using UnityEngine.Audio;
using UnityEngine;
using System;
using System.ComponentModel;

public class AudioManager : MonoBehaviour
{

    /**
     * Audio manager design from: https://www.youtube.com/watch?v=6OT43pvUyfY
     * 
     * To play a sound anywhere for any event:
     * FindObjectOfType<AudioManager>().Play("SoundName");
     * 
     * Add sounds in inspector within the array sounds
     */

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }


        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.priority = s.priority;
        }
    }

    void Start() {
        //Play("Stun");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.Play();
    }
}
