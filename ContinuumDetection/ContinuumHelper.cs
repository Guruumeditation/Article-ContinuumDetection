using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace ContinuumDetection
{
    public static class ContinuumHelper
    {
        public static bool IsContinuumMode => (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile") && (UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse);
    }
}
