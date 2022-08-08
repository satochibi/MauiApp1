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

        // Open a stream to the template workbook file.

        var file = await FilePicker.Default.PickAsync();
        if (file == null)
        {
            await DisplayAlert("file is null", "nothing", "ok");
            return;
        }


        if (!file.FileName.EndsWith("xlsx", StringComparison.OrdinalIgnoreCase))
        {
            await DisplayAlert("not xlsx file", file.FileName.ToString(), "ok");
            return;
        }

        using var readStream = await file.OpenReadAsync();

        // https://www.spreadsheetgear.com/nuget/spreadsheetgear/tutorials/mvc-web-app-excel-reporting-from-template/visual-studio-for-windows/
        
        // Create a new "workbook set" object and open the above file stream.
        SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();
        SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.OpenFromStream(readStream);
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;

        valueLabel.Text = cells[0, 0].Value.ToString();
    }



}

