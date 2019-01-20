using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using omdb.Helpers;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(omdb.iOS.VersioniOS))]
namespace omdb.iOS
{
    public class VersioniOS : IAppVersion
    {
        public string GetOS()
        {
            return "ios";
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }

        public int GetBuild()
        {
            return int.Parse(NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString());
        }
    }
}