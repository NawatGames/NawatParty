using MiniGame;
using MiniGame.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameManagement.StateScripts
{
    public class MiniGameLoader : StateScript
    {
        public UnityEvent onMiniGameLoaded;

        protected override void OnEnable()
        {
            base.OnEnable();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected override void OnStateEnter()
        {
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;
            if (!currentMiniGame) Debug.LogError("Trying to enter a MiniGame without setting a game declarator");

            SceneManager.LoadScene(currentMiniGame.gameScene.name);
        }

        protected override void OnStateExit()
        {
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;

            Scene currentMiniGameScene = SceneManager.GetSceneByPath(currentMiniGame.gameScene.path);
            SceneManager.UnloadSceneAsync(currentMiniGameScene);

            SceneManager.SetActiveScene(gameObject.scene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.path != MiniGameManager.Instance.CurrentMiniGame.gameScene.path) return;
            onMiniGameLoaded.Invoke();
            SceneManager.SetActiveScene(scene);
        }
    }
}
