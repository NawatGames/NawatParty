using MiniGame;
using MiniGame.Data;
using UnityEditor;
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

            SceneManager.LoadScene(currentMiniGame.GameScene.name);
        }

        protected override void OnStateExit()
        {
            MiniGameDeclarator currentMiniGame = MiniGameManager.Instance.CurrentMiniGame;

            Scene currentMiniGameScene = SceneManager.GetSceneByName(currentMiniGame.GameScene.name);
            SceneManager.UnloadSceneAsync(currentMiniGameScene);

            SceneManager.SetActiveScene(gameObject.scene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != MiniGameManager.Instance.CurrentMiniGame.GameScene.name) return;
            onMiniGameLoaded.Invoke();
            SceneManager.SetActiveScene(scene);
        }
    }
}
