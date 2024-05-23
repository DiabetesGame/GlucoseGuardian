using UnityEngine;
using UnityEngine.UI;

public class MenuPage : MonoBehaviour
{
    [SerializeField]
    private MenuPage parent;
    public MenuPage Parent => parent;

    [SerializeField]
    private MenuPage[] children;
    public MenuPage[] Children => children;

    [SerializeField]
    private Image[] panel;
    public Image[] Panel => panel;

    [SerializeField]
    private GameObject hologram;

    private int selectedIndex = 0;

    private void Start()
    {
        HighlightCurrentSelection();
    }
    public int SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = Mathf.Clamp(value, 0, panel.Length - 1); }
    }

    public void HighlightCurrentSelection()
    {
        for (int i = 0; i < panel.Length; i++)
        {
            panel[i].enabled = (i == selectedIndex);
        }
    }

    public void MoveSelectionUp()
    {
        if (panel.Length == 0) return;  // Check if there are no panels
        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : panel.Length - 1;
        HighlightCurrentSelection();
    }

    public void MoveSelectionDown()
    {
        if (panel.Length == 0) return;  // Check if there are no panels
        selectedIndex = (selectedIndex < panel.Length - 1) ? selectedIndex + 1 : 0;
        HighlightCurrentSelection();
    }

    public void ResetSelection()
    {
        selectedIndex = 0;
        HighlightCurrentSelection();
    }

    public MenuPage GetSelectedChildPage()
    {
        if (children == null || children.Length == 0) return null;  // Check if there are no children
        return (children.Length > selectedIndex) ? children[selectedIndex] : null;
    }

    public void ShowPage()
    {
        gameObject.SetActive(true);
    }

    public void HidePage()
    {
        gameObject.SetActive(false);
    }
}