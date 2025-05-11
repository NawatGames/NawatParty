using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement.StateScripts
{
    /// <summary>
    /// Unloads current miniGame
    /// State script should be set to listen to MiniGame state
    /// </summary>
    public class MiniGameUnloader : StateScript
    {
        [SerializeField] private MiniGameManager miniGameManager;
        [SerializeField] private string sceneName;

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();

            Scene miniGameScene = SceneManager.GetSceneByName(miniGameManager.CurrentMiniGame.GameScene.name);
            SceneManager.UnloadSceneAsync(miniGameScene);

            Scene boardScene = SceneManager.GetSceneByName(sceneName);
            foreach (GameObject obj in boardScene.GetRootGameObjects())
            {
                obj.SetActive(true);
            }

            SceneManager.SetActiveScene(boardScene);
        }
    }
}
