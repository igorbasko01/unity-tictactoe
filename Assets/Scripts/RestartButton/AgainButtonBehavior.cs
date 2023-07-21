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
            _againButton.onClick.AddListener(HideButton);
        }
    }

    public void OnDestroy() {
        _gameManagerEvents.OnEndGame -= ShowButton;
        if (_againButton != null) {
            _againButton.onClick.RemoveListener(HideButton);
        }
    }

    private void ShowButton(EndGameCondition endGameCondition, PlayerMark playerMark) {
        if (_againButton == null) {
            return;
        }
        _againButton.gameObject.SetActive(true);
    }

    private void HideButton() {
        if (_againButton == null) {
            return;
        }
        _againButton.gameObject.SetActive(false);
    }
}
