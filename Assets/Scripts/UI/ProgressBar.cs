using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
// A class for a custom progressbar that has both a linear and radial form.
[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour {
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar() {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/LinearProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
    [MenuItem("GameObject/UI/Radial Progress Bar")]
    public static void AddRadialProgressBar() {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/RadialProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif
    // Variables
    public int maximum;
    public int minimum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    // Update is called once per frame
    void Update() {
        GetCurrentFill();
    }

    void GetCurrentFill() {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    // Setters
    public void SetMax(int value) {
        maximum = value;
    }
    public void SetCurrent(int value) {
        current = value;
    }
}
