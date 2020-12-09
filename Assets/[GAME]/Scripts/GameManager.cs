using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void OnEnable()
    {
        EventManager.OnGameOver.AddListener(GameOver);
    }

    private void OnDisable()
    {
        EventManager.OnGameOver.RemoveListener(GameOver);
    }


    public void GameOver()
    {
        StartCoroutine(LoadNextSceneRoutine());
    }

    private IEnumerator LoadNextSceneRoutine()
    {

        

        //Sonraki bölüm atamış olmak
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Scene initScene = SceneManager.GetSceneAt(0);
        SceneManager.SetActiveScene(initScene);


        if (buildIndex != 1)
        {
            yield return SceneManager.UnloadSceneAsync(buildIndex-1);
        }

        //int sceneCount = SceneManager.sceneCount;

        //List<Scene> scenesToBeUnloaded = new List<Scene>();

        //for (int i = 0; i < sceneCount; i++)
        //{
        //    Scene scene = SceneManager.GetSceneAt(i);
        //    if (scene.name.Contains("Level"))
        //    {
        //        scenesToBeUnloaded.Add(scene);
        //    }
        //}

        //foreach (var scene in scenesToBeUnloaded)
        //{
        //    yield return SceneManager.UnloadSceneAsync(scene.buildIndex);
        //}

        if (!Application.CanStreamedLevelBeLoaded(buildIndex))
        {
            buildIndex = 1;
        }


        yield return SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        
        Scene levelScene = SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.SetActiveScene(levelScene);

        PlayerPrefs.SetString("LastLevel", levelScene.name);


    }
}
