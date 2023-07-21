using UnityEngine;
using UnityEngine.UI;

public class AgainButtonBehavior : MonoBehaviour
{
    [SerializeField] private Button _againButton;

    private GameManagerEvents _gameManagerEvents;

    public void SetGameManagerEvents(GameManagerEvents gameManagerEvents) {
        _gameManagerEvents = gameManagerEvents;
        _gameManagerEvents.OnEndGame += ShowButton;
        if (_againButton != null) {
            _againButton.onClick.AddListener(RestartAndHideButton);
        }
    }

    public void OnDestroy() {
        _gameManagerEvents.OnEndGame -= ShowButton;
        if (_againButton != null) {
            _againButton.onClick.RemoveListener(RestartAndHideButton);
        }
    }

    private void ShowButton(EndGameCondition endGameCondition, PlayerMark playerMark) {
        if (_againButton == null) {
            return;
        }
        _againButton.gameObject.SetActive(true);
    }

    private void RestartAndHideButton() {
        if (_againButton == null) {
            return;
        }
        _gameManagerEvents.InvokeOnRestartGame();
        _againButton.gameObject.SetActive(false);
    }
}
