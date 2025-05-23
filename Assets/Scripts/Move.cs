using DG.Tweening;
using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField][Min(0)] private float _time = 3;
	[SerializeField] private Vector3 _targetPosition;

	private void Start()
	{
		transform.DOMove(_targetPosition, _time).SetLoops(-1, LoopType.Restart);
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}
}
