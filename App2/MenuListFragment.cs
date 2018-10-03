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
    public class MenuListFragment : Fragment
    {

        private Activity _parentActivity;

        private SimpleAdapter _adapter;
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

            View view = inflater.Inflate(Resource.Layout.fragment_menu_list, container, false);

            ListView lvMenu = view.FindViewById<ListView>(Resource.Id.lvMenu);

            var menuList = new JavaList<IDictionary<string, object>>();

            JavaDictionary<string, object> menu = new JavaDictionary<string, object>();
            menu.Add("name", "からあげ");
            menu.Add("price", "300");
            menuList.Add(menu);

            menu = new JavaDictionary<string, object>();
            menu.Add("name", "バグった食べ物☆");
            menu.Add("price", "28.8200");
            menuList.Add(menu);

            menu = new JavaDictionary<string, object>();
            menu.Add("name", "ごみ");
            menu.Add("price", "3333300");
            menuList.Add(menu);

            string[] from = { "name", "price" };
            int[] to = { Android.Resource.Id.Text1, Android.Resource.Id.Text2 };


            _adapter = new SimpleAdapter(_parentActivity, menuList, Android.Resource.Layout.SimpleListItem2, from, to);

            lvMenu.Adapter = _adapter;

            lvMenu.ItemClick += OnItemClick;
            
            return view;


        }
        private void OnItemClick(object sender,AdapterView.ItemClickEventArgs e)
        {
            var item = _adapter.GetItem(e.Position);
            string menuName = (((JavaDictionary<string, object>)item)["name"]).ToString();
            string menuPrice = (((JavaDictionary<string, object>)item)["price"]).ToString();

            Intent intent = new Intent(_parentActivity, typeof(MenuThanksActivity));
            intent.PutExtra("menuName", menuName);
            intent.PutExtra("menuPrice", menuPrice);

            StartActivity(intent);
        }
    }
}