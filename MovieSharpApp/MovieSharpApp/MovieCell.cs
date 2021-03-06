﻿using System;
using Xamarin.Forms;

namespace MovieSharpApp
{
	public class MovieCell : ViewCell
	{
		public MovieCell()
		{
			// TODO: add PosterPath  http://image.tmdb.org/t/p/w500/nBNZadXqJSdt05SHLqgT0HuC5Gm.jpg
			// Movie title label.
			var titleLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			titleLabel.SetBinding(Label.TextProperty, "Title");

			// Movie tagline label.
			var voteAverageLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			voteAverageLabel.SetBinding(Label.TextProperty, "VoteAverage");

			// Creates a StackLayout view with the movie and vote average labels.
			View = new StackLayout {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = {
					titleLabel, voteAverageLabel
				}
			};
		}
	}
}

