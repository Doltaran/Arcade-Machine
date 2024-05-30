using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; // Добавляем пространство имен для работы с SceneManager

namespace PixelAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TeleportAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;
        [SerializeField] private float _playerDetectionRadius = 5f; // Радиус обнаружения игрока
        [SerializeField] private LayerMask _playerLayer; // Слой игрока
        [SerializeField] private string _sceneToLoad; // Название сцены для загрузки

        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentSprite;
        private float _spriteUpdateTime;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate;
            _spriteUpdateTime = Time.time + _secondsPerFrame;
        }

        private void Update()
        {
            if (_spriteUpdateTime > Time.time) return;

            // Проверяем, находится ли игрок рядом
            if (Physics2D.OverlapCircle(transform.position, _playerDetectionRadius, _playerLayer))
            {
                if (_currentSprite >= _sprites.Length)
                {
                    if (_loop)
                    {
                        _currentSprite = 0;
                    }
                    else
                    {
                        _onComplete?.Invoke();
                        LoadNextScene(); // Загружаем следующую сцену при завершении анимации
                        enabled = false; // Отключаем скрипт, когда анимация завершена
                        return;
                    }
                }

                _renderer.sprite = _sprites[_currentSprite];
                _spriteUpdateTime += _secondsPerFrame;
                _currentSprite++;
            }
            else
            {
                // Если игрок ушел, сбрасываем анимацию на первый кадр
                _currentSprite = 0;
                _renderer.sprite = _sprites[_currentSprite];
                _spriteUpdateTime = Time.time + _secondsPerFrame; // Обновляем время следующего обновления спрайта
            }
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(_sceneToLoad); // Загружаем следующую сцену по её названию
        }
    }
}
