using Android.App;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Details")]			
	public class DetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Details);
            // para recuperar el item lo optenemos con la pripiedad GetIntExtra heredado de Intent
			int position = base.Intent.GetIntExtra( "ItemPosition", -1);

			// TODO

			var item = MainActivity.Items[position];

			FindViewById<TextView>(Resource.Id.nameTextView ).Text = "Name: "  + item.Name;
			FindViewById<TextView>(Resource.Id.countTextView).Text = "Count: " + item.Count.ToString();
		}
	}
}