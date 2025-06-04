using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public AudioSource loopSound;
    public AudioSource enemyLoop;
    //public AudioSource AudioSource;
    public bool isMute = false;
    public float volume = 1.0f;

    // This is an array of all the sound entries (each has a type and an AudioClip).
    public GameSounds[] gameSounds;
    private void Awake()
    {
        // If no SoundManager exists yet, this becomes the instance.
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetVolume(0.5f);
        PlayBGMusic(SoundTypes.GameplayMusic); 
    }

    public void Play(SoundTypes soundType)
    {
        if (isMute)
        {
            return;
        }
        AudioClip clip = GetSoundType(soundType);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for soundType" + soundType);
        }
    }
    public void PlayBGMusic(SoundTypes soundType)
    {
        if (isMute)
        {
            return;
        }
        AudioClip clip = GetSoundType(soundType);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for soundType" + soundType);
        }
    }

    public void PlayRunLoop()
    {
        if (!loopSound.isPlaying && !isMute)
        {
            loopSound.Play();
        }
        else
        {
            Debug.LogWarning("Loop is not running");   
        }
    }

    public void StopRunLoop()
    {
        if (loopSound.isPlaying && isMute)
        {
            loopSound.Stop();
        }
    }

    public void PlayEnemyLoop()
    {
        if (!enemyLoop.isPlaying && !isMute)
        {
            enemyLoop.Play();
        }
        else
        {
            Debug.LogWarning("Loop is not running");
        }
    }
    public void StopEnemyLoop()
    {
        if (enemyLoop.isPlaying && isMute)
        {
            enemyLoop.Stop();
        }
    }

    public void Mute(bool status)
    {
        isMute = status;
    }

    public void SetVolume(float gameVolume)
    {
       volume = gameVolume;
        soundEffect.volume = volume;
        soundMusic.volume = volume; 
    }


    private AudioClip GetSoundType(SoundTypes soundType)
    {
        // Search the sounds array for an item that matches the given sound type.
        GameSounds item = Array.Find(gameSounds, i => i.soundType == soundType);
        // If a matching item was found, return its AudioClip.
        if (item != null)
        {
          return item.soundClip;
        }
        
        return null;
    }
}

[Serializable]
public class GameSounds
{
   public SoundTypes soundType;
    public AudioClip soundClip;
}
public enum SoundTypes
{
    ButtonClick,
    EnemyDeath,
    GameplayMusic,
    PlayerWalk,
    PlayerRun,
    PlayerDeath,
    LevelComplete,
    PlayerJump,
    PlayerLand,
    KeyCollect,
    ChomperWalk,
    ChomperAttack,
    GameStart,
    BackButton,
}

