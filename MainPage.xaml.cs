namespace MauiApp1;

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
        // Button button = (Button)sender;
        // await DisplayAlert("Clicked!", "The button labeled '" + button.Text + "' has been clicked", "OK");
        
        // Create a new empty workbook in a new workbook set.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();

        // Get a reference to the first worksheet.
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];

        // Get a reference to the top left cell of Sheet1.
        SpreadsheetGear.IRange a1 = worksheet.Cells["A1"];

        // Set a formula.
        a1.Formula = "=24901.55 / PI()";

        await DisplayAlert("clicked",a1.Value.ToString(), "ok");
    }

}

