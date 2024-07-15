using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Loading : MonoBehaviour
{

   [Header("----Loading------")]
   [SerializeField] GameObject LoadingPanel;
   [SerializeField] private Image LoadingFill_UI;
   [SerializeField] private float TimeDuration;



    private void Start()
    {
        LoadingFill();
    }

    void LoadingFill()
    {
        LoadingFill_UI.DOFillAmount(1f, TimeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

  
}
