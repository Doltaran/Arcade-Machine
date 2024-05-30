using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; // ��������� ������������ ���� ��� ������ � SceneManager

namespace PixelAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TeleportAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;
        [SerializeField] private float _playerDetectionRadius = 5f; // ������ ����������� ������
        [SerializeField] private LayerMask _playerLayer; // ���� ������
        [SerializeField] private string _sceneToLoad; // �������� ����� ��� ��������

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

            // ���������, ��������� �� ����� �����
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
                        LoadNextScene(); // ��������� ��������� ����� ��� ���������� ��������
                        enabled = false; // ��������� ������, ����� �������� ���������
                        return;
                    }
                }

                _renderer.sprite = _sprites[_currentSprite];
                _spriteUpdateTime += _secondsPerFrame;
                _currentSprite++;
            }
            else
            {
                // ���� ����� ����, ���������� �������� �� ������ ����
                _currentSprite = 0;
                _renderer.sprite = _sprites[_currentSprite];
                _spriteUpdateTime = Time.time + _secondsPerFrame; // ��������� ����� ���������� ���������� �������
            }
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(_sceneToLoad); // ��������� ��������� ����� �� � ��������
        }
    }
}
