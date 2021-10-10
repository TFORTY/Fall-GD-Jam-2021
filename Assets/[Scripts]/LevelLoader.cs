using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int ilevelToLoad;
    [SerializeField] string slevelToLoad;
    [SerializeField] bool useIntergerToLoadLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            LoadScene();
            FindObjectOfType<Player>().SetSpeed(5);
            FindObjectOfType<Player>().ResetTargetSpeedUpPos();
        }
    }

    void LoadScene()
    {
        if (useIntergerToLoadLevel)
        {
            SceneManager.LoadScene(ilevelToLoad);

        }
        else
        {
            SceneManager.LoadScene(slevelToLoad);
        }     
    }
}