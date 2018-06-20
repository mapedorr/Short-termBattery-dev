using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class BorderHighlight : MonoBehaviour
{
	// ══════════════════════════════════════════════════════════════ PUBLICS ════
	public Sprite normal;
	public Sprite over;

	// ═════════════════════════════════════════════════════════════ PRIVATES ════
	AC.Highlight m_highlight;
	SpriteRenderer m_spriteRenderer;

	// ══════════════════════════════════════════════════════════════ METHODS ════
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		// get the reference to the Highlight script
		m_highlight = GetComponent<AC.Highlight> ();

		// get the SpriteRenderer component
		m_spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start ()
	{
		// set the default Sprite
		if (m_spriteRenderer != null)
		{
			m_spriteRenderer.sprite = normal;
		}

		if (m_highlight != null)
		{
			// add listeners to OnHighlightOn and OnHighlightOff events
			m_highlight.onHighlightOn.AddListener (OnHighlightOn);
			m_highlight.onHighlightOff.AddListener (OnHighlightOff);
		}
	}

	void OnHighlightOn ()
	{
		// change the Sprite so the object shows its border
		if (m_spriteRenderer != null && over != null)
		{
			m_spriteRenderer.sprite = over;
		}
	}

	void OnHighlightOff ()
	{
		// change the Sprite so the object shows its default
		if (m_spriteRenderer != null)
		{
			m_spriteRenderer.sprite = normal;
		}
	}
}