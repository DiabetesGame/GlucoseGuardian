using UnityEngine;

public class RightMenuController : MonoBehaviour
{
    [Header("Menu Pages")]
    [SerializeField] private MenuPage topPage;
    [SerializeField] private MenuPage currentPage;

    private void OnEnable()
    {
        if (topPage != null)
        {
            currentPage = topPage;
            currentPage.ShowPage();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpPage();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownPage();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterPage();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            BackPage();
        }
    }

    public void TopPage()
    {
        if (topPage != null)
        {
            currentPage.HidePage();
            currentPage = topPage;
            currentPage.ShowPage();
        }
    }

    public void BackPage()
    {
        if (currentPage.Parent != null)
        {
            currentPage.HidePage();
            currentPage = currentPage.Parent;
            currentPage.ShowPage();
        }
    }

    public void EnterPage()
    {
        MenuPage selectedChildPage = currentPage.GetSelectedChildPage();
        if (selectedChildPage != null)
        {
            currentPage.HidePage();
            currentPage = selectedChildPage;
            currentPage.ShowPage();
        }
        else
        {
            Debug.LogWarning("No children to enter.");
        }
    }

    public void UpPage()
    {
        if (currentPage != null)
        {
            currentPage.MoveSelectionUp();
        }
    }

    public void DownPage()
    {
        if (currentPage != null)
        {
            currentPage.MoveSelectionDown();
        }
    }
}