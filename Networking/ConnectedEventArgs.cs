using System;

namespace ExileNET.Networking
{
    public class ConnectedEventArgs : EventArgs
    {
        public int Status { get; internal set; }

        public string URL { get; internal set; }
    }
}