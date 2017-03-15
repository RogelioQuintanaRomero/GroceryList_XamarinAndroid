using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e)
		{
			string name  = FindViewById<EditText>(Resource.Id.nameInput).Text;
			int    count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);
            // para pasar valores declaramos un nuevo itent
            var intent = new Intent();
            // agregamos las variables a enviar al itnent atravez de PutExtra como key-value
            intent.PutExtra("ItemName", name);
            intent.PutExtra("ItemCount", count);
  //          Continue working in the OnSaveClick method of the AddItemActivity.
//Call the version of SetResult that takes two parameters.Pass Result.Ok and the Intent.
            SetResult(Result.Ok, intent);
            Finish();
            // TODO
        }

		void OnCancelClick(object sender, EventArgs e)
		{
            // TODO
            base.Finish();

        }
    }
}