using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
	[SerializeField][Min(0)] private float _time = 3;
	[SerializeField] private Color _targetColor;

	private Renderer _renderer;
	private Material _materialInstance;

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
		_materialInstance = new Material(_renderer.material);
		_renderer.material = _materialInstance;
	}

	private void Start()
	{
		_materialInstance.DOColor(_targetColor, _time).SetLoops(-1, LoopType.Restart);
	}

	private void OnDestroy()
	{
		if (_materialInstance != null)
		{
			_materialInstance.DOKill();

			Destroy(_materialInstance);
		}
	}
}
