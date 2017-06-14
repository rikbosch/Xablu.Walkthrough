using Plugin.Xablu.Walkthrough.Abstractions;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Plugin.Xablu.Walkthrough.Themes;
using Plugin.Xablu.Walkthrough.Abstractions.Containers;
using Plugin.Xablu.Walkthrough.Containers;
using Walker;
using Plugin.Xablu.Walkthrough.Pages;

namespace Plugin.Xablu.Walkthrough
{
    /// <summary>
    /// Implementation for Android
    /// </summary>
    public class WalkthroughImplementation : Java.Lang.Object, ViewPager.IOnPageChangeListener, IWalkthrough
    {
        private WalkthroughViewPagerBaseFragment viewPagerFragment;
        private AppCompatActivity hostActvity;

        private int currentPosition = 0;

        public void Init(AppCompatActivity hostActivity)
        {
            hostActvity = hostActivity;
        }

        public void Setup<TPage, TContainer>(ITheme<TPage, TContainer> theme) where TPage : IPage where TContainer : IContainer
        {
            var androidTheme = theme.Container as BaseContainer;
            var pages = theme.Pages.ToArray() as WalkerFragment[];

            viewPagerFragment = androidTheme;
            viewPagerFragment.SetAdapter(pages, hostActvity);
            viewPagerFragment.SetListener(this);
        }

        public void Previous()
        {
            viewPagerFragment.ViewPager.CurrentItem = currentPosition - 1;
        }

        public void Next()
        {
            viewPagerFragment.ViewPager.CurrentItem = currentPosition + 1;
        }

        public void Show()
        {
            viewPagerFragment.Show(hostActvity.SupportFragmentManager, Class.SimpleName);
        }

        public void Close()
        {
            viewPagerFragment.ViewPager.CurrentItem = 0;
            viewPagerFragment.Dismiss();
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageSelected(int position)
        {
            currentPosition = position;
        }
    }
}