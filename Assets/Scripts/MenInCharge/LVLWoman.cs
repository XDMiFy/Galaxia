using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLWoman : MonoBehaviour
{
    public GameObject OrigGroup;
    private EvilDudeEnemyGroup currentScript; 
    private int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
            CreateNewGroup();
            amount++;
    }

    // Update is called once per frame
    void Update()
    {
        if( currentScript.isNotBoom == false && currentScript != null){
            Destroy(currentScript.gameObject);
            if( amount == 3){
                SceneManager.LoadSceneAsync(ScreenIDs.WinScreenID);
            }else
            {
                CreateNewGroup();
                amount++;
            }
           
        }
    }

    void CreateNewGroup()
    {
        GameObject NewGroup = Instantiate(OrigGroup);
        NewGroup.transform.position = transform.position; 
        currentScript = NewGroup.GetComponent<EvilDudeEnemyGroup>();
    }
}
