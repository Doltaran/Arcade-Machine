using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Platform[] platforms; // ������ ��������

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
        foreach (Platform platform in platforms)
        {
            if (platform.platformNumber == platformNumber)
            {
                platform.collider2D.enabled = true;
                break;
            }
        }
    }
}
