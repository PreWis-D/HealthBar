using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _image;

    private Player _player;
    private Slider _slider;
    private float _duration = 0.3f;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.Health;
        _image.color = _gradient.Evaluate(1f);
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
            DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        _slider.DOValue(_player.Health, _duration).SetEase(Ease.Linear);
        _image.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
