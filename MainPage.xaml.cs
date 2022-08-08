﻿namespace MauiApp1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        valueLabel.Text = args.NewValue.ToString("F3");
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
        Button button = (Button)sender;
        await DisplayAlert("Clicked!", "The button labeled '" + button.Text + "' has been clicked", "OK");
    }

}

