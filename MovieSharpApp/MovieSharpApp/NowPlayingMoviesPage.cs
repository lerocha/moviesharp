using System;
using Xamarin.Forms;
using System.Collections.Generic;
using MovieSharp.Data;
using System.Diagnostics;
using MovieSharp;

namespace MovieSharpApp
{
	public class NowPlayingMoviesPage : ContentPage
	{
		private ListView listView;

		/// <summary>
		/// Initializes a new instance of the <see cref="MovieSharpApp.NowPlayingMoviesPage"/> class.
		/// </summary>
		public NowPlayingMoviesPage()
		{
			Title = "Now Playing";

			listView = new ListView {
				RowHeight = 80
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			try {
				// TODO: replace with the real API key
				IMovieSharpClient movieSharpClient = new MovieSharpClient("_YOUR_API_KEY_");

				var response = await movieSharpClient.GetNowPlayingMoviesAsync();
				if (response.IsOk) {
					listView.ItemsSource = response.Body.Results;
					listView.ItemTemplate = new DataTemplate(typeof(MovieCell));
				}
			} catch (Exception e) {
				// TODO: handle exception
				Debug.WriteLine(e);
			}
		}
	}
}

