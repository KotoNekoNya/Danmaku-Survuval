using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        // „N„p„x„~„p„‰„p„u„} „†„…„~„{„ˆ„y„ RestartScene() „~„p „ƒ„€„q„„„„y„u „~„p„w„p„„„y„‘ „{„~„€„„{„y
        GetComponent<Button>().onClick.AddListener(RestartScene);
    }

    private void RestartScene()
    {
        // „P„€„|„…„‰„p„u„} „y„~„t„u„{„ƒ „„„u„{„…„‹„u„z „p„{„„„y„r„~„€„z „ƒ„ˆ„u„~„
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // „B„€„x„€„q„~„€„r„|„‘„u„} „r„‚„u„}„‘ „r „y„s„‚„u
        Time.timeScale = 1; 

        // „P„u„‚„u„x„p„s„‚„…„w„p„u„} „ƒ„ˆ„u„~„… „„€ „u„v „y„~„t„u„{„ƒ„…
        SceneManager.LoadScene(currentSceneIndex);
    }
}
