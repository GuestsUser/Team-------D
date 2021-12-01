using UnityEngine;

public class replayBall: MonoBehaviour
{
    [SerializeField]
   
    private GameObject REplay;

    // Update is called once per frame
    void Update()
    {
       
        GameObject playerObj = GameObject.Find(REplay.name);

        // playerObjが存在していない場合
        if (playerObj == null)
        {
            // playerPrefabから新しくGameObjectを作成
            GameObject newPlayerObj = Instantiate(REplay);

            newPlayerObj.name = REplay.name;

        }
    }
}