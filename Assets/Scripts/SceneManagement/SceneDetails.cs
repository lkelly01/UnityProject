using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetails : MonoBehaviour
{
    [SerializeField] List<SceneDetails> connectedScenes;
    [SerializeField] AudioClip sceneMusic;

    public bool IsLoaded { get; private set; }

    List<SavableEntity> savableEntities;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log($"Entered {gameObject.name}");

            LoadScene();
            GameController.Instance.SetCurrentScene(this);

            if (sceneMusic != null)
                AudioManager.i.PlayMusic(sceneMusic, fade: true);

            // Load all connected scenes
            foreach (var scene in connectedScenes)
            {
                scene.LoadScene();
            }

            // Unload the scenes that are no longer connected
            var prevScene = GameController.Instance.PrevScene;
            if (prevScene != null)
            {
                var previouslyLoadedScenes = prevScene.connectedScenes;
                foreach (var scene in previouslyLoadedScenes)
                {
                    if (!connectedScenes.Contains(scene) && scene != this)
                        scene.UnloadScene();
                }

                if (!connectedScenes.Contains(prevScene))
                    prevScene.UnloadScene();
            }
        }
    }

    public void LoadScene()
    {
        if (!IsLoaded)
        {
            var operation = SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            IsLoaded = true;

            operation.completed += (AsyncOperation op) =>
            {
                savableEntities = GetSavableEntitiesInScene();
                if (savableEntities != null)
                {
                    SavingSystem.i.RestoreEntityStates(savableEntities);
                }
                else
                {
                    Debug.LogError("No savable entities found in the scene.");
                }
            };
        }
    }

    public void UnloadScene()
{
    if (IsLoaded)
    {
        if (savableEntities != null)
        {
            SavingSystem.i.CaptureEntityStates(savableEntities);
        }
        else
        {
            Debug.LogWarning("savableEntities is null. Skipping capture process.");
        }

        SceneManager.UnloadSceneAsync(gameObject.name);
        IsLoaded = false;
    }
}


    List<SavableEntity> GetSavableEntitiesInScene()
    {
    var currScene = SceneManager.GetSceneByName(gameObject.name);
    var savableEntities = FindObjectsOfType<SavableEntity>().Where(x => x.gameObject.scene == currScene).ToList();
    return savableEntities;
    }


    public AudioClip SceneMusic => sceneMusic;
}
