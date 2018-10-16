using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace PhoneCallApp
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        EditText phoneNumberInput;
        Button callButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            phoneNumberInput = FindViewById<EditText>(Resource.Id.PhoneNumber);
            callButton = FindViewById<Button>(Resource.Id.CallButton);
            callButton.Click += CallButton_Click;
        }

        private void CallButton_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
            var phoneNumber = phoneNumberInput.Text;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                var callDialog = new Android.App.AlertDialog.Builder(this);
                callDialog.SetMessage("Do you want to call " + phoneNumber + "?");
                callDialog.SetNeutralButton("Call", delegate {
                    var callIntent = new Intent(Intent.ActionDial);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));
                    StartActivity(callIntent);
                });
                callDialog.SetNegativeButton("Cancel", delegate { });
                callDialog.Show();
            } else
            {
                var toast = Toast.MakeText(this, "Please provide number", new ToastLength());
                toast.Show();
            }

        }
    }
}