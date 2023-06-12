using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Surface Info")]
public class SurfaceInfo : ScriptableObject
{
	[Serializable]
	public class EffectPair
	{
		public AudioClip[] AudioEffect;
		public GameObject VisualEffect;
	}

	public EffectPair Impact;
}