using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Global surface effects system
/// </summary>
public class SurfaceManager : Singleton<SurfaceManager>
{
	[SerializeField]
	private bool m_SpatializeAudio = false;

	[SerializeField]
	private SurfaceInfo m_DefaultSurface;

	[Space]

	[SerializeField]
	private string m_SurfacesPath = "Surfaces/";

	[SerializeField]
	private SurfaceInfo[] m_Surfaces;


	public static void SpawnEffect(int surfaceId, SurfaceEffects effectType, float audioVolume, Vector3 position, Quaternion rotation)
	{
		SurfaceInfo surfInfo = Instance.GetSurfaceWithId(surfaceId);
		PoolableObject effect = PoolingManager.Instance.GetObject(surfInfo.GetInstanceID().ToString() + effectType.ToString());

		if (effect != null)
		{
			effect.transform.position = position;
			effect.transform.rotation = rotation;
			effect.GetComponent<SurfaceEffect>().Play(audioVolume);
		}
	}

	private SurfaceInfo GetSurfaceWithId(int surfaceId)
	{
		if (m_Surfaces.Length > surfaceId && surfaceId >= 0)
			return m_Surfaces[surfaceId];

		return null;
	}

	private void Awake()
	{
		m_Surfaces = Resources.LoadAll<SurfaceInfo>(m_SurfacesPath);
		CacheSurfaceEffects();
	}

	private void CacheSurfaceEffects()
	{
		foreach (SurfaceInfo surfInfo in m_Surfaces)
		{
			string surfInstanceId = surfInfo.GetInstanceID().ToString();

			CreatePoolForEffect(surfInfo.name + "_" + SurfaceEffects.Impact.ToString(), surfInfo.Impact, 25, 50, true, surfInstanceId + SurfaceEffects.Impact.ToString());
			if (m_DefaultSurface != null && m_DefaultSurface.name == surfInfo.name)
				m_DefaultSurface = surfInfo;
		}
	}

	private void CreatePoolForEffect(string name, SurfaceInfo.EffectPair effectPair, int poolSizeMin, int poolSizeMax, bool autoShrink, string poolId)
	{
		GameObject effectTemplate = new GameObject(name);
		SurfaceEffect effectComponent = effectTemplate.AddComponent<SurfaceEffect>();
		effectComponent.Init(effectPair.AudioEffect, effectPair.VisualEffect, m_SpatializeAudio);

		PoolingManager.Instance.CreatePool(effectTemplate, poolSizeMin, poolSizeMin, autoShrink, poolId, 5f);

		Destroy(effectTemplate);
	}
}