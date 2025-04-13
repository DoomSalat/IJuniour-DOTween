using DG.Tweening;
using UnityEngine;

public class Scale : MonoBehaviour
{
	[SerializeField][Min(0)] private float _time = 3;
	[SerializeField] private Vector3 _targetScale;

	private void Start()
	{
		transform.DOScale(_targetScale, _time).SetLoops(-1, LoopType.Restart);
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}
}
