using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class BasementButton : MonoBehaviour
{
	// ══════════════════════════════════════════════════════════════ PUBLICS ════
	public Sprite buttonPressed;
	public int value;
	public Basement basementLogic;
	public AC.Hotspot buttonHotspot;

	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	SpriteRenderer m_spriteRenderer;
	Sprite m_defaultSprite;
	AudioSource m_audioSource;

	// ══════════════════════════════════════════════════════════════ METHODS ════
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		m_spriteRenderer = GetComponent<SpriteRenderer> ();
		m_audioSource = GetComponent<AudioSource> ();

		// store the default Sprite for the button
		if (m_spriteRenderer != null)
		{
			m_defaultSprite = m_spriteRenderer.sprite;
		}
	}

	/// <summary>
	/// Disables the Hotspot for the button, changes its Sprite and sets the value
	/// for the current strong box combination
	/// </summary>
	public void PressButton ()
	{
		// disable the Hotspot linked to the button
		if (buttonHotspot != null)
		{
			buttonHotspot.TurnOff ();
		}

		// change the button sprite
		if (m_spriteRenderer != null && buttonPressed != null)
		{
			m_spriteRenderer.sprite = buttonPressed;
		}

		// play the sound effect
		if (m_audioSource != null)
		{
			m_audioSource.Play ();
		}

		// send the value of the button to the current combination of the strong box
		if (basementLogic != null)
		{
			basementLogic.AddCombinationStep (value);
		}
	}

	/// <summary>
	/// Enables the Hotspot for the button and changes its Sprite to the default one
	/// </summary>
	public void ResetButton ()
	{
		// enable the Hotspot
		if (buttonHotspot != null)
		{
			buttonHotspot.TurnOn ();
		}

		// change the Sprite to it default value
		if (m_spriteRenderer != null && m_defaultSprite != null)
		{
			m_spriteRenderer.sprite = m_defaultSprite;
		}
	}
}