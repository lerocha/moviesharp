using System;
using Xamarin.Forms;
using MovieSharp;
using MovieSharp.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace MovieSharpApp
{
	public class App
	{
		public static Page GetMainPage()
		{
			return new NowPlayingMoviesPage();
		}
	}
}

