using UnityEngine;
using UnityEngine.Events;

namespace PixelAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimationWithSpawn : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;
        [SerializeField] private Transform _spawnPoint; // ��������� ���� ��� ����� ������
        public GameObject objectToTeleport;
        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentSprite;
        private float _spriteUpdateTime;
        public Animator objectAnimator;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate;
            _spriteUpdateTime = Time.time + _secondsPerFrame;
        }

        private void Update()
        {
            if (_spriteUpdateTime <= Time.time)
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
                        enabled = false; // ��������� ������ ����� ���������� ��������
                        return;
                    }
                }

                _renderer.sprite = _sprites[_currentSprite];
                _spriteUpdateTime += _secondsPerFrame;
                _currentSprite++;
            }

            // ���������, ����� �� ����������� �������� � ����� ������
            if (_currentSprite >= _sprites.Length && _spawnPoint != null)
            {
                objectToTeleport.transform.position = _spawnPoint.position;
                objectAnimator.SetTrigger("Appear");

            }
        }
    }
}
