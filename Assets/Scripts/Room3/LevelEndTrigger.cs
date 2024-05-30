using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public LevelEndScreen levelEndScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelEndScreen.ShowEndScreen();
            RemoveMusicObject();
        }
    }

    private void RemoveMusicObject()
    {
        GameObject musicObject = GameObject.Find("BGMusic1");
        if (musicObject != null)
        {
            Destroy(musicObject);
        }
    }
}
