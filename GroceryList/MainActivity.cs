using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GroceryList
{
	[Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public static List<Item> Items = new List<Item>();

		protected override void OnCreate(Bundle bundle)
		{
			Items.Add(new Item("Milk",     2));
			Items.Add(new Item("Crackers", 1));
			Items.Add(new Item("Apples",   5));

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			FindViewById<Button>(Resource.Id.itemsButton  ).Click += OnItemsClick;
			FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
			FindViewById<Button>(Resource.Id.aboutButton  ).Click += OnAboutClick;
		}

		void OnItemsClick(object sender, EventArgs e)
		{
            var intent = new Intent(this, typeof(ItemsActivity));
            StartActivity(intent);
			// TODO
		}

		void OnAddItemClick(object sender, EventArgs e)
		{
            var intent = new Intent(this, typeof(AddItemActivity));
            //StartActivity(intent);
            //para recibir resultado no ocupamos StarActivity
            //para recibir notificacion ocupamos el siguiente metodo agregando intent como primer parametro y 100 como segundo parametro
            // en espera del resultado
            StartActivityForResult(intent, 100);
            // al cargar este parametro continua su funcion el metodo OnAtivityResult para recibir los resutados qeu se espera obtener
            // TODO
        }

		void OnAboutClick(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(typeof( AboutActivity));
            // TODO
        }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
            //var intent = new Intent(this, typeof(ItemsActivity));
            //StartActivity(intent);
            // TODO
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                // declaramos dos variables e lso qeu recibiremos parametros 
                string name = data.GetStringExtra("ItemName");
                int count = data.GetIntExtra("ItemCount",-1);
                //creamos nevo item en el que agregaremos los dos valores que recibimos
                Items.Add(new Item(name, count));
            }
        }
	}
}