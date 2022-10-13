using System;
using Xamarin.Forms;

namespace Lab1
{
    public partial class MainPage : ContentPage
    {
        private int columns = 10, rows = 10, min = 0, max = 100, fontSize = 24;
        private bool findMin = true;

        public MainPage()
        {
            InitializeComponent();

            // random matrix and result array generation
            Random rnd = new Random();
            int[,] matrix = new int[columns, rows];
            int[] result = new int[columns];
            for (int i = 0; i < columns; i++)
            {
                result[i] = findMin ? max : min;
                for (int j = 0; j < rows; j++)
                    matrix[i, j] = rnd.Next(min, max);
            }

            GenerateGrid(matrix, result);
        }

        private void GenerateGrid(int[,] matrix, int[] result)
        {
            // creating rows and columns in grid layout
            // and two additional rows for the result
            for (int i = 0; i < rows + 2; i++)
                myGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < columns; i++)
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // filling grid with values from matrix 
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    // comparing the current value with the value in the result array
                    if (findMin ? matrix[columnIndex, rowIndex] < result[columnIndex] : matrix[columnIndex, rowIndex] > result[columnIndex])
                        result[columnIndex] = matrix[columnIndex, rowIndex];

                    myGrid.Children.Add(new Label
                    {
                        Text = matrix[columnIndex, rowIndex].ToString(),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.Black,
                        FontSize = fontSize
                    }, columnIndex, rowIndex);
                }
            }

            // printing the answer
            var label = new Label
            {
                Text = findMin ? "Minimum:" : "Maximum:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                FontSize = fontSize
            };
            myGrid.Children.Add(label, 0, rows);
            Grid.SetColumnSpan(label, columns);

            for (int columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                myGrid.Children.Add(new Label
                {
                    Text = result[columnIndex].ToString(),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.Black,
                    FontSize = fontSize
                }, columnIndex, rows + 1);
            }
        }
    }
}
