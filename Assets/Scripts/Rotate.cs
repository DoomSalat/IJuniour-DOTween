using DG.Tweening;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField][Min(0)] private float _time = 3;
	[SerializeField] private Vector3 _targetRotation;

	private void Start()
	{
		transform.DORotate(_targetRotation, _time).SetLoops(-1, LoopType.Restart);
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}
}
