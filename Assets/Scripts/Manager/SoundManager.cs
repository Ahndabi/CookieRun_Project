using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;
	GameObject audioObject;
	AudioSource source;

	private void Awake()
	{
		audioObject = new GameObject("GetItemSound");
		source = audioObject.AddComponent<AudioSource>();

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else
			Destroy(gameObject);
	}

	public void SFXPlay(string sfxName, AudioClip clip)
	{
		GameObject go = new GameObject(sfxName + "Sound");
		AudioSource audioSource = go.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();

		Destroy(go, clip.length);
	}

    public void SFXPlaye_My(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void DestroySound(string sfxName, AudioClip clip)
	{
	}
}
