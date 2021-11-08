using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Targil2
{
   public  class RemoteControl
    {
        const int MAX_TEMPERTURE = 32;
        const int MIN_TEMPERTURE = 16;
       public  enum Status
        {
            On = 0,
            Off = 1
        };
        #region attributes
        private int _temperture;
        #endregion

        #region properties
        public int Temperture
        {
            get { return _temperture; }
            set
            {
                if (value > MAX_TEMPERTURE || value < MIN_TEMPERTURE)
                    throw new ArgumentOutOfRangeException($"טמפרטורה חייבת להיות בין {MAX_TEMPERTURE} - {MIN_TEMPERTURE}");
                else
                    _temperture = value;
            }

        }

        public Status status { get; set; }
        #endregion

        #region C'tor
        public RemoteControl()
        {
            _temperture = MIN_TEMPERTURE;
            status = Status.Off;
        }
        #endregion
    }
}