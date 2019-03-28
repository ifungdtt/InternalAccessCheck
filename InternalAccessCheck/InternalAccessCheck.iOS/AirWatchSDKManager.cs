using System;
using AirWatchSDK;
using System.Diagnostics;
using Foundation;

namespace InternalAccessCheck.iOS
{
    public class AirWatchSDKManager : AWSDKDelegate
    {
        const string LogCategory = "AirWatchSDKManager";

        public const string InitializationStartedNotification = "InitializationStartedNotification";
        public const string InitialCheckDoneWithErrorNotification = "InitialCheckDoneWithErrorNotification";
        public const string ReceivedProfilesNotification = "ReceivedProfilesNotification";

        private static AirWatchSDKManager instance;

        // private, use the Instance below
        private AirWatchSDKManager()
        {
        }

        // singleton pattern
        public static AirWatchSDKManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AirWatchSDKManager();
                }
                return instance;
            }
        }

        // Below are all the protocol methods defined in AWSDKDelegate
        // Add customization here for SDK results

        override public void InitialCheckDoneWithError(NSError error)
        {
            // Add any SDK Customization here
            string message = String.Format("InitialCheckDoneWithError received {0}, SDK initialized if no error", error);
            Debug.WriteLine(message, LogCategory);
            NSNotificationCenter.DefaultCenter.PostNotificationName(InitialCheckDoneWithErrorNotification, null);
        }

        override public void ReceivedProfiles(AWProfile[] profiles)
        {
            // Add any SDK Customization here
            string message = String.Format("ReceivedProfiles received {0}", profiles);
            Debug.WriteLine(message, LogCategory);
            NSNotificationCenter.DefaultCenter.PostNotificationName(ReceivedProfilesNotification, null);
        }

        override public void Wipe()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Wipe command received", LogCategory);
        }

        override public void Lock()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Lock command received", LogCategory);
        }

        override public void Unlock()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Unlock command received", LogCategory);
        }

        override public void StopNetworkActivity(AWNetworkActivityStatus networkActivityStatus)
        {
            // Add any SDK Customization here
            Debug.WriteLine("StopNetworkActivity received", LogCategory);
        }

        override public void ResumeNetworkActivity()
        {
            // Add any SDK Customization here
            Debug.WriteLine("ResumeNetworkActivity received", LogCategory);
        }
    }
}