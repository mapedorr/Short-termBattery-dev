﻿using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class Basement : MonoBehaviour
{
	// ══════════════════════════════════════════════════════════════ PUBLICS ════
	public Transform strongboxLedsLight;
	public GameObject strongboxGO;
	public Sprite openStrongbox;
	public Sprite openStrongboxOver;
	public GameObject bagGO;
	[Range (1, 3)]
	public int requiredCombinations;

	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	string m_currentCombination;
	int m_currentCombinationIndex;
	string[] m_openCombinations = new string[3];
	BasementButton[] m_strongboxButtons;
	// displacement taken from moving the object in the Editor
	// 		strongbocLedsLight 0: -1.169
	// 		strongbocLedsLight 1: -0.918
	// 		strongbocLedsLight 2: -0.667
	// 		strongbocLedsLight 3: -0.416
	float ledsLightXDisplacement = 0.251f;

	// ══════════════════════════════════════════════════════════════ METHODS ════
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		m_currentCombination = "";
		m_currentCombinationIndex = 0;
		m_openCombinations[0] = "123456";
		m_openCombinations[1] = "354216";
		m_openCombinations[2] = "253146";
		m_strongboxButtons = GameObject.FindObjectsOfType<BasementButton> ();
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start ()
	{
		if (strongboxLedsLight != null)
		{
			// place the LEDs light out of its mask
			strongboxLedsLight.localPosition =
				new Vector3 (-1.169f, strongboxLedsLight.localPosition.y, 0f);
		}
	}

	IEnumerator ResetStrongbox ()
	{
		yield return new WaitForSeconds (2);

		foreach (BasementButton button in m_strongboxButtons)
		{
			button.ResetButton ();
		}

		// End the cutscene
		KickStarter.stateHandler.EndCutscene ();
	}

	IEnumerator OpenStrongbox ()
	{
		// TODO: play sound effect of all combinations done

		yield return new WaitForSeconds (2);

		// play sound effect of strongbox opening

		// change the Sprite of the strongbox to the open one
		if (strongboxGO != null)
		{
			strongboxGO.GetComponent<SpriteRenderer> ().sprite = openStrongbox;
			BorderHighlight sbBorderHighlight = strongboxGO.GetComponent<BorderHighlight> ();
			sbBorderHighlight.normal = openStrongbox;
			sbBorderHighlight.over = openStrongboxOver;
		}

		// make the bag appear on the screen
		if (bagGO != null)
		{
			bagGO.SetActive (true);
		}

		// deactivate the LEDs
		strongboxLedsLight.gameObject.SetActive (false);

		// change the value of the local variable: strongboxOpen
		AC.LocalVariables.SetBooleanValue (0, true);

		// End the cutscene
		KickStarter.stateHandler.EndCutscene ();
	}

	public void AddCombinationStep (int number)
	{
		m_currentCombination += number;
		if (m_currentCombination.Length == 6)
		{
			// check if the current combination matches the expected combination of the
			// current step
			if (m_openCombinations[m_currentCombinationIndex].Equals (m_currentCombination))
			{
				// Place the game in a cutscene
				KickStarter.stateHandler.StartCutscene ();

				// move the LEDs' light to the next LED
				strongboxLedsLight.localPosition += Vector3.right * ledsLightXDisplacement;

				// change the index of the combination to match
				m_currentCombinationIndex++;

				// check if all the combinations have been done to open the Strong Box
				if (m_currentCombinationIndex >= requiredCombinations)
				{
					// open the strongbox
					StartCoroutine (OpenStrongbox ());
					return;
				}
				else
				{
					// TODO: play sound effect of combination success
				}
			}
			else
			{
				// TODO: play sound effect of combination failure
			}

			// clear the current combination
			m_currentCombination = "";

			// reset all the hotsposts in the Strong Box and make the default
			// button Sprites visible again
			if (m_strongboxButtons.Length > 0)
			{
				StartCoroutine (ResetStrongbox ());
			}
		}
	}
}