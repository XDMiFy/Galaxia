using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public void StartLVL1() 
    {
        SceneManager.LoadSceneAsync(ScreenIDs.GameSceneID);
    }
}
