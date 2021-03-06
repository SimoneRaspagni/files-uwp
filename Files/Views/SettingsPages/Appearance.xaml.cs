﻿using Files.Enums;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;


namespace Files.SettingsPages
{
	public sealed partial class Appearance : Page
	{
		public Appearance()
		{
			InitializeComponent();

			List<string> _themeval = new List<string>();
			_themeval.Add(ResourceController.GetTranslation("SystemTheme"));
			_themeval.Add(ResourceController.GetTranslation("LightTheme"));
			_themeval.Add(ResourceController.GetTranslation("DarkTheme"));
			ThemeChooser.ItemsSource = _themeval;

			ThemeStyle _selectedTheme = App.AppSettings.ThemeValue;

			ThemeChooser.SelectedIndex = (int)Enum.Parse(typeof(ThemeStyle), _selectedTheme.ToString());
			ThemeChooser.Loaded += (s, e) =>
			{
				ThemeChooser.SelectionChanged += async (s1, e1) =>
				{
					var themeComboBox = s1 as ComboBox;

					switch (themeComboBox.SelectedIndex)
					{
						case 0:
							App.AppSettings.ThemeValue = ThemeStyle.System;
							break;
						case 1:
							App.AppSettings.ThemeValue = ThemeStyle.Light;
							break;
						case 2:
							App.AppSettings.ThemeValue = ThemeStyle.Dark;
							break;
					}

					//await RestartReminder.Fade(value: 1.0f, duration: 1500, delay: 0).StartAsync();
					//await RestartReminder.Fade(value: 0.0f, duration: 1500, delay: 0).StartAsync();
				};
			};
			

			//Load App Time Style
			List<string> _dateformatval = new List<string>();
			_dateformatval.Add(ResourceController.GetTranslation("ApplicationTimeStye"));
			_dateformatval.Add(ResourceController.GetTranslation("SystemTimeStye"));
			DateFormatChooser.ItemsSource = _dateformatval;

			TimeStyle _selectedFormat = App.AppSettings.DisplayedTimeStyle;
			DateFormatChooser.SelectedIndex = (int)Enum.Parse(typeof(TimeStyle), _selectedFormat.ToString());
			DateFormatChooser.Loaded += (s, e) =>
			{
				DateFormatChooser.SelectionChanged += async (s1, e1) =>
				{
					var timeStyleComboBox = s1 as ComboBox;

					switch (timeStyleComboBox.SelectedIndex)
					{
						case 0:
							App.AppSettings.DisplayedTimeStyle = TimeStyle.Application;
							break;
						case 1:
							App.AppSettings.DisplayedTimeStyle = TimeStyle.System;
							break;
					}

					//await TimeFormatReminder.Fade(value: 1.0f, duration: 1500, delay: 0).StartAsync();
					//await TimeFormatReminder.Fade(value: 0.0f, duration: 1500, delay: 0).StartAsync();
				};
			};
		}

	}
}
