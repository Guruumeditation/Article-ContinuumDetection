using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace ContinuumDetection
{
    public class ContinuumStateTrigger : StateTriggerBase
    {
        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State", typeof(ContinuumState), typeof(ContinuumStateTrigger), new PropertyMetadata(default(ContinuumState), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var t = dependencyObject as ContinuumStateTrigger;

            t?.SetActive(t.GetContinuumState() == t.State);
        }

        public ContinuumState State
        {
            get { return (ContinuumState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public ContinuumStateTrigger()
        {
            Window.Current.SizeChanged += CurrentOnSizeChanged;
        }

        private void CurrentOnSizeChanged(object sender, WindowSizeChangedEventArgs windowSizeChangedEventArgs)
        {
            SetActive(GetContinuumState() == State);
        }

        private ContinuumState GetContinuumState()
        {
            return (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile") && (UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse) ? ContinuumState.Continuum : ContinuumState.Base;
        }
    }

    public enum ContinuumState
    {
        Base = 0,
        Continuum = 1
    }
}
