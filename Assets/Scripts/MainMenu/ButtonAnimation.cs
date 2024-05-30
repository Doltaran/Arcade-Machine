using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAnimation: MonoBehaviour
{
    public Animator[] levelAnimators; // ������ ���������� �������
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayLevelAnimation);

    }

    void PlayLevelAnimation()
    {
        // ���������, ��� ������ ���������� ���������� � �� ������
        if (levelAnimators != null && levelAnimators.Length > 0)
        {
            // ����������� �������� ��� ������� ������
            foreach (Animator animator in levelAnimators)
            {
                if (animator != null)
                {
                    animator.SetTrigger("Play");
                }
                else
                {
                    Debug.LogWarning("Animator not assigned to LevelSelectButton!");
                }
            }
        }
        else
        {
            Debug.LogWarning("No animators assigned to LevelSelectButton!");
        }
    }
   

}
