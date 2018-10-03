using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App2
{
    public class MenuThanksFragment : Fragment
    {

        private Activity _parentActivity;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            _parentActivity = Activity;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.fragment_menu_thanks, container, false);

            Intent intent = _parentActivity.Intent;
            Bundle extras = intent.Extras;

            string menuName = "";
            string menuPrice = "";

            if (extras!=null)
            {
                menuName = extras.GetString("menuName");
                menuPrice = extras.GetString("menuPrice");
            }

            TextView tvMenuName = view.FindViewById<TextView>(Resource.Id.tvMenuName);
            TextView tvMenuPrice = view.FindViewById<TextView>(Resource.Id.tvMenuPrice);

            tvMenuName.Text = menuName;
            tvMenuPrice.Text = menuPrice;

            Button btBackButton = view.FindViewById<Button>(Resource.Id.btBackButton);
            btBackButton.Click+= (s,e) => { _parentActivity.Finish(); };
           
            return view;
        }

      
    }
}