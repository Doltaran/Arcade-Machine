using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Platform[] platforms; // ������ ��������
    public SpriteRenderer[] platformRenderers; // ������ �������� ��������
    void Start()
    {
        // ��������� ���������� ��� ��������� ��������
        DisableColliders();
    }

    // ����� ��� ���������� ����������� � ��������� ��������
    private void DisableColliders()
    {
        foreach (Platform platform in platforms)
        {
            if (platform.disableColliderOnStart)
            {
                platform.collider2D.enabled = false;
            }
        }
    }

    // ����� ��� ��������� ���������� � ��������� ���������
    public void ActivatePlatform(int platformNumber)
    {
        platformRenderers[platformNumber].enabled = true;
        foreach (Platform platform in platforms)
        {
            if (platform.platformNumber == platformNumber)
            {
                platform.collider2D.enabled = true;
                break;
            }
        }
    }
    public void SetPlatformSprite(int platformNumber, Sprite newSprite)
    {
        platformRenderers[platformNumber].sprite = newSprite;
    }
}
