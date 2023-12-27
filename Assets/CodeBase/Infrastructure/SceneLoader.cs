using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure {
    public class SceneLoader {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner CoroutineRunner) => _coroutineRunner = CoroutineRunner;

        public void Load(string Name, Action OnLoaded = null){
            _coroutineRunner.StartCoroutine(LoadScene(Name, OnLoaded));
        }

        public IEnumerator LoadScene(string NextScene, Action OnLoaded = null){
            if (SceneManager.GetActiveScene().name == NextScene){
                OnLoaded?.Invoke();
                yield break;
            }
            AsyncOperation waitAsync = SceneManager.LoadSceneAsync(NextScene);
            while (!waitAsync.isDone){
                yield return null;
            }
            OnLoaded?.Invoke();
        }
    }
}