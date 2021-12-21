using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
  public Sound[] sounds;

  void Awake()
  {
    foreach (Sound s in sounds)
    {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.isPlaying = false;
    }
  }

  // Update is called once per frame
  public void Play(string name)
  {
    Sound s = Array.Find(sounds, Sound => Sound.name == name);
    if (s.isPlaying = false)
    {
      s.source.Play();   
      s.isPlaying = true;
    }
    else{
      s.source.Stop();
      s.isPlaying = false;
    }
  }

  public void Stop(string name)
  {

    Sound s = Array.Find(sounds, Sound => Sound.name == name);
    if (s.isPlaying = true)
    {
      s.source.Stop();
      s.isPlaying = false;
    }
    else{
      s.source.Play(); 
    }

  }
}
