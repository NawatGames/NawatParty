using MiniGame.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameManagement.StateScripts
{
    public class MiniGameLoader : StateScript
    {
        public UnityEvent onMiniGameLoaded;

        private Scene _oldScene;

        protected override void OnEnable()
        {
            base.OnEnable();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected override void OnStateEnter()
        {
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;
            if (!currentMiniGame) Debug.LogError("Trying to enter a MiniGame without setting a game declarator");

            // Disable old scene objects
            _oldScene = SceneManager.GetActiveScene();
            GameObject[] oldSceneGameObjects = _oldScene.GetRootGameObjects();
            foreach (GameObject oldSceneGameObject in oldSceneGameObjects) oldSceneGameObject.SetActive(false);

            // Load Scene
            SceneManager.LoadSceneAsync(currentMiniGame.GameScene.name, LoadSceneMode.Additive);
        }

        protected override void OnStateExit()
        {
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;

            Scene currentMiniGameScene = SceneManager.GetSceneByName(currentMiniGame.GameScene.name);
            SceneManager.UnloadSceneAsync(currentMiniGameScene);

            SceneManager.SetActiveScene(_oldScene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Check if loaded scene is the mini-game's scene
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;
            if (!currentMiniGame || scene.name != currentMiniGame.GameScene.name) return;
            Debug.Log(currentMiniGame.GameScene.name);
            onMiniGameLoaded.Invoke();
            SceneManager.SetActiveScene(scene);
        }
    }
}
