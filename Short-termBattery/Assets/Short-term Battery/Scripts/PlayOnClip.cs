using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnClip : MonoBehaviour
{
	// ══════════════════════════════════════════════════════════════ PUBLICS ════
	public AudioClip audioClip;
	public AudioSource audioSource;
	public AudioClip[] alternateAudioClips;

	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	int _currentIndex;

	// ══════════════════════════════════════════════════════════════ METHODS ════
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		_currentIndex = 0;
	}

	void PlayClip ()
	{
		if (audioClip != null && audioSource != null)
		{
			audioSource.PlayOneShot (audioClip);
		}
	}

	void PlayAlternateClip ()
	{
		if (audioSource != null && alternateAudioClips.Length > 0)
		{
			if (_currentIndex >= alternateAudioClips.Length)
			{
				_currentIndex = 0;
			}

			audioSource.PlayOneShot (alternateAudioClips[_currentIndex++]);
		}
	}
}