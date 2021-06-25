using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// 
/// This is the GameplayManager and should manage:
/// 1) Game behaviour including loading NPCs
/// 2) Ability to change between scenes
/// 3) Menu System
/// 4) reference to the player, NPCs, EventObjects
/// 

public class GameplayManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
}
