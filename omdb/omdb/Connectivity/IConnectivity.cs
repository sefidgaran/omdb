using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace omdb.Connectivity
{
    public interface IConnectivity
    {
        bool IsConnected();

        bool IsConnectedToWifi();

        bool IsConnectedToMobileNetwork();

        void ListenToConnectivityChanges(Action<object, ConnectivityTypeChangedEventArgs> onChangeHandler);

        void RemoveListenerFromConnectivityChanges();
    }
}
