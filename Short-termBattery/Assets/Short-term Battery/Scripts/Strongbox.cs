using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strongbox : MonoBehaviour
{
	public AudioSource strongboxOpened;
	public AudioSource combinationFailure;
	public AudioSource combinationSuccess;

	/// <summary>
	/// Plays the sound effect for the strongbox opening
	/// </summary>
	public void PlayStrongboxOpened ()
	{
		if (strongboxOpened != null)
		{
			strongboxOpened.Play ();
		}
	}

	/// <summary>
	/// Plays the sound effect of an erred combination
	/// </summary>
	public void PlayCombinationFailure ()
	{
		if (combinationFailure != null)
		{
			combinationFailure.Play ();
		}
	}

	/// <summary>
	/// Plays the sound effect of a guessed combination
	/// </summary>
	public void PlayCombinationSuccess ()
	{
		if (combinationSuccess != null)
		{
			combinationSuccess.Play ();
		}
	}
}