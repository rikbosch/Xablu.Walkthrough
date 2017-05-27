﻿using System;
using System.Collections.Generic;
using BWWalkthrough;
using Plugin.Xablu.Walkthrough.Abstractions.Pages;
using Plugin.Xablu.Walkthrough.ViewControllers;
using UIKit;

namespace Plugin.Xablu.Walkthrough.Containers
{
    public partial class ForestPrimesContainer : BWWalkthroughViewController
    {
        private IList<ForestPrimesPage> pages = new List<ForestPrimesPage>();
        public IList<ForestPrimesPage> Pages
        {
            get => pages;
            set => pages = value;
        }

        public ForestPrimesContainer() : base("ForestPrimesContainer", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            for (int i = 0; i < Pages.Count; i++)
            {
                var page = new ForestPrimesViewController();
                page.PageTitle = Pages[i].Title;
                AddViewController(page);
            }

            NextButton.TouchUpInside += (sender, e) =>
            {
                this.NextPage();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void WalkthroughCloseButtonPressed()
        {
            //  throw new NotImplementedException();
        }

        public void WalkthroughNextButtonPressed()
        {
            //  throw new NotImplementedException();
        }

        public void WalkthroughPrevButtonPressed()
        {
            //  throw new NotImplementedException();
        }

        public void WalkthroughPageDidChange(int pageNumber)
        {
            //  throw new NotImplementedException();
        }
    }
}
