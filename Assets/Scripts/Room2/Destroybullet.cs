using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybullet : MonoBehaviour
{   
    
    float TimeToDisable = 500f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisabled());
    }

    // Update is called once per frame
    

    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(TimeToDisable);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisabled());
        gameObject.SetActive(false);
    }
}
