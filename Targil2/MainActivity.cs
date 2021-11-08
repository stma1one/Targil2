using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using System;

namespace Targil2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        Button upBtn, downBtn, onBtn, offBtn;
        TextView tvTemp;
        RemoteControl rc;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitMembers();
            InitViews();


        }

        private void InitViews()
        {
            upBtn = FindViewById<Button>(Resource.Id.btnPlus);
            downBtn = FindViewById<Button>(Resource.Id.btnMinus);
            onBtn = FindViewById<Button>(Resource.Id.btnOn);
            offBtn = FindViewById<Button>(Resource.Id.btnOff);
            tvTemp = FindViewById<TextView>(Resource.Id.tvTemp);
            upBtn.SetOnClickListener(this);
            downBtn.SetOnClickListener(this);
            offBtn.SetOnClickListener(this);
            onBtn.SetOnClickListener(this);
            TurnOff();




        }

        private void InitMembers()
        {
            try
            {
                rc = new RemoteControl()
                {
                    status = RemoteControl.Status.Off
                };

            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void DisplayTemp()
        {
            tvTemp.Text = rc.Temperture.ToString();
        }

        public void OnClick(View v)
        {
            try
            {
                switch (v.Id)
                {
                    case Resource.Id.btnPlus:
                        if (rc.status == RemoteControl.Status.On)
                        {
                            rc.Temperture++;
                            DisplayTemp();
                        }
                        break;
                    case Resource.Id.btnMinus:
                        if (rc.status == RemoteControl.Status.On)
                        {
                            rc.Temperture--;
                            DisplayTemp();
                        }
                        break;
                    case Resource.Id.btnOff:
                        TurnOff();
                        break;
                    case Resource.Id.btnOn:
                        TurnOn();
                        DisplayTemp();
                        break;
                    default:
                        break;
                }




            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }



        }

        private void TurnOff()
        {
            rc.status = RemoteControl.Status.Off; 
            tvTemp.Text = "";
            downBtn.Enabled = false;
            upBtn.Enabled = false;
            onBtn.Enabled = true;
            offBtn.Enabled = false;
        }

        private void TurnOn()
        {
            rc.status = RemoteControl.Status.On;
            downBtn.Enabled = true;
            upBtn.Enabled = true;
            onBtn.Enabled = false;
            offBtn.Enabled = true;
        }
    }
}