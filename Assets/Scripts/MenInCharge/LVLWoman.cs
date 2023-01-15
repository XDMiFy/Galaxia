using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLWoman : MonoBehaviour
{
    public GameObject OrigGroup;
    public GameObject WreckGroupOrig;
    private BasedGroup currentScript; 
    private int amount = 0;
    private EnemyGroupType[] evilTypes = { EnemyGroupType.evilDudeGroup, EnemyGroupType.wreckGroup};
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
            if( amount == evilTypes.Length){
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
        if (evilTypes[amount] == EnemyGroupType.evilDudeGroup){
        GameObject NewGroup = Instantiate(OrigGroup);
        NewGroup.transform.position = transform.position; 
        currentScript = NewGroup.GetComponent<EvilDudeEnemyGroup>();
        } else if (evilTypes[amount] == EnemyGroupType.wreckGroup){
            GameObject NewGroup = Instantiate(WreckGroupOrig);
        NewGroup.transform.position = transform.position; 
        currentScript = NewGroup.GetComponent<WreckEnemyGroup>();
        }
    }
}
//sandwiches
