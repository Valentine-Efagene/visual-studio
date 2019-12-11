using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This only works in .NET Framework 4.0 or later and Windows 7 or later.

// If the application is not allowed to use location services,
// the watcher's StatusChanged event never fires.

// Note that the CivicAddressResolver class's ResolveAddress method has not
// yet been implemented so you can't convert this into a street address.

// Add a reference to System.Device.
using System.Device.Location;

namespace LongLat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;

        // Create and start the watcher.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();

            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;

            // Start the watcher.
            Watcher.Start();
        }

        // The watcher's status has change. See if it is ready.
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    txtLat.Text = "Cannot find location data";
                }
                else
                {
                    txtLat.Text = Watcher.Position.Location.Latitude.ToString();
                    txtLong.Text = Watcher.Position.Location.Longitude.ToString();
                }
            }
        }
    }
}
