using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(TMP_Text))]
public class TextChangerTMP : MonoBehaviour
{
	[Header("Основные настройки")]
	[SerializeField] private float _time = 2f;
	[SerializeField] private float _delayBetweenEffects = 0.5f;

	[Header("Тексты для анимации")]
	[SerializeField]
	private List<string> _textVariants = new List<string>
	{
		"Hello World",
		"Here Unity",
		"New place"
	};

	private TMP_Text _tmpText;
	private Sequence _animationSequence;
	private string _originalText;

	private void Awake()
	{
		_tmpText = GetComponent<TMP_Text>();
		_originalText = _tmpText.text;
	}

	private void Start()
	{
		CreateAnimationSequence();
		_animationSequence.Play();
	}

	private void CreateAnimationSequence()
	{
		_animationSequence = DOTween.Sequence();

		_animationSequence.AppendCallback(() => _tmpText.text = _originalText);
		AddReplaceEffect(_textVariants[0]);
		_animationSequence.AppendCallback(() => _tmpText.text = _originalText);
		AddAppendEffect(_textVariants[1]);
		_animationSequence.AppendCallback(() => _tmpText.text = _originalText);
		AddScrambleWriteTypeEffect(_textVariants[2]);

		_animationSequence.SetLoops(-1);
	}

	private void AddReplaceEffect(string targetText)
	{
		_animationSequence.Append(
			_tmpText.DOText(targetText, _time)
				.SetEase(Ease.Linear)
		);

		_animationSequence.AppendInterval(_delayBetweenEffects);
	}

	private void AddAppendEffect(string targetText)
	{
		_animationSequence.Append(
			_tmpText.DOText(targetText, _time).SetRelative()
				.SetEase(Ease.Linear)
		);

		_animationSequence.AppendInterval(_delayBetweenEffects);
	}

	private void AddScrambleWriteTypeEffect(string targetText)
	{
		_animationSequence.Append(
			_tmpText.DOText(targetText, _time, true, ScrambleMode.All)
				.SetEase(Ease.InOutQuad)
		);

		_animationSequence.AppendInterval(_delayBetweenEffects);
	}

	private void OnDestroy()
	{
		if (_animationSequence != null && _animationSequence.IsActive())
		{
			_animationSequence.Kill();
		}
	}
}