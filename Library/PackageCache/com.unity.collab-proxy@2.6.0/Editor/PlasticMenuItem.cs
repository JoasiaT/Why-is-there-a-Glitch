using UnityEditor;
using Unity.PlasticSCM.Editor.UI;

namespace Unity.PlasticSCM.Editor
{
    internal static class PlasticMenuItem
    {
        [MenuItem(MENU_ITEM_NAME, false)]
        static void ShowPanel()
        {
            PlasticPlugin.OpenPlasticWindowDisablingOfflineModeIfNeeded();
        }

        const string MENU_ITEM_NAME = "Window/" + UnityConstants.PLASTIC_WINDOW_TITLE;
    }
}
