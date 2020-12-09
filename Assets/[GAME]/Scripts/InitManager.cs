using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //PlayerPrefs oyun akışını etkileyen işlemlerde kullanılmamalıdır.
        //Additive → Init sahnesini silmeden yeni bir sahne yükleneceği için kullandık.
        yield return SceneManager.LoadSceneAsync(PlayerPrefs.GetString("LastLevel", "Level01"), LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(PlayerPrefs.GetString("LastLevel", "Level01")));
        Destroy(gameObject);
    }

}
