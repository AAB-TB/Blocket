using System;
using System.Data.SqlClient;
using System.Configuration;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics;

namespace Blocket
{
    public partial class Form1 : Form
    {
        string connectionString = Configuration.GetConnectionString();
        public Form1()
        {
            InitializeComponent();
            Load += async (sender, e) => await LoadDataAsync();


        }

        public async Task LoadDataAsync()
        {
            try
            {
                List<Ad> collectionItemDataList = await RetrieveDataFromDatabaseAsync();

                // Clear existing user controls in the FlowLayoutPanel.
                flowLayoutPanel1.Controls.Clear();

                foreach (Ad data in collectionItemDataList)
                {
                    ItemUserControl itemUserControl = new ItemUserControl(this, data);
                    itemUserControl.SetImage(data.FrontImagePath);
                    itemUserControl.SetTitle(data.Title);
                    flowLayoutPanel1.Controls.Add(itemUserControl);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private async Task<List<Ad>> RetrieveDataFromDatabaseAsync()
        {
            List<Ad> adDataList = new List<Ad>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    await connection.OpenAsync();

                    // SQL query to select data from Ads table
                    string sqlQuery = "SELECT AdID, Title, Description, Price, CategoryID, FrontImagePath, SecondImagePath FROM Ads";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int adID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            string title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            string description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            decimal price = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                            int categoryID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            string frontImagePath = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                            string secondImagePath = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

                            // Create an Ad object and add it to the list
                            Ad ad = new Ad
                            {
                                AdID = adID,
                                Title = title,
                                Description = description,
                                Price = price,
                                CategoryID = categoryID,
                                FrontImagePath = frontImagePath,
                                SecondImagePath = secondImagePath
                            };
                            adDataList.Add(ad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                MessageBox.Show($"An error occurred in the RetrieveDataFromDatabaseAsync method. {ex}");
            }

            return adDataList;
        }



        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hmeBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void addItemsBtn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private async void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchtextbox.Text;

            try
            {
                // Implement autocomplete logic here
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // Call a method to get and display autocomplete suggestions
                    DisplayAutocompleteSuggestions(searchText);
                }
                else
                {
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }
        private async void DisplayAutocompleteSuggestions(string searchText)
        {
            try
            {
                // Query the database for autocomplete suggestions
                List<string> suggestions = await GetAutocompleteSuggestionsAsync(searchText);

                // Clear the ListBox before adding new suggestions
                suggestionsListBox.Items.Clear();

                if (suggestions.Count > 0)
                {
                    // Add suggestions to the ListBox
                    suggestionsListBox.Items.AddRange(suggestions.ToArray());

                    // Show the ListBox below the search TextBox
                    suggestionsListBox.Location = new Point(searchtextbox.Location.X, searchtextbox.Location.Y + searchtextbox.Height);
                    suggestionsListBox.Visible = true;
                }
                else
                {
                    // If there are no suggestions, hide the ListBox
                    suggestionsListBox.Visible = false;
                }
            }
            catch (Exception ex)
            {


                // Show a user-friendly error message
                MessageBox.Show("An error occurred while displaying autocomplete suggestions: " + ex.Message);
            }
        }
        private async Task<List<string>> GetAutocompleteSuggestionsAsync(string searchText)
        {
            List<string> suggestions = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();


                    string sqlQuery = @"
                                    SELECT A.Title, C.CategoryName
                                    FROM Ads A
                                    JOIN Categories C ON A.CategoryID = C.CategoryID
                                    WHERE (A.Title LIKE @searchText + '%' OR C.CategoryName LIKE @searchText + '%');
                                    ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", searchText);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                suggestions.Add(reader.GetString(0)); // Add item titles
                                suggestions.Add(reader.GetString(1)); // Add category names
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log detailed error information using NLog
                MessageBox.Show($"An error occurred in GetAutocompleteSuggestionsAsync for search text: {ex}");

                // You can choose to re-throw the exception if needed
                throw;
            }

            return suggestions;
        }

        private void suggestionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (suggestionsListBox.SelectedIndex != -1)
                {
                    string selectedSuggestion = suggestionsListBox.SelectedItem.ToString();
                    // Set the selected suggestion as the text in the searchTextBox
                    searchtextbox.Text = selectedSuggestion;
                    // Perform the search based on the selected suggestion
                    PerformSearch(selectedSuggestion);

                    // Explicitly hide the suggestionsListBox
                    suggestionsListBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                
                // Show a user-friendly error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private async void PerformSearch(string selectedSuggestion)
        {
            try
            {
                List<Ad> searchResults = await SearchItemsAsync(selectedSuggestion);
                suggestionsListBox.Visible = false;
                // Clear existing user controls in the FlowLayoutPanel.
                flowLayoutPanel1.Controls.Clear();

                foreach (Ad data in searchResults)
                {
                    ItemUserControl itemUserControl = new ItemUserControl(this, data);
                    itemUserControl.SetImage(data.FrontImagePath);
                    itemUserControl.SetTitle(data.Title);
                    flowLayoutPanel1.Controls.Add(itemUserControl);
                }
            }
            catch (Exception ex)
            {
                
                // Show a user-friendly error message
                MessageBox.Show("An error occurred during the search: " + ex.Message);
            }
        }

        private async Task<List<Ad>> SearchItemsAsync(string searchText)
        {
            List<Ad> searchResults = new List<Ad>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sqlQuery = @"
                SELECT A.AdID, A.Title, A.FrontImagePath
                FROM Ads A
                JOIN Categories C ON A.CategoryID = C.CategoryID
                WHERE (A.Title LIKE @searchText + '%' OR C.CategoryName LIKE @searchText + '%');
            ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int adID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0); // Handle potential NULL in AdID
                                string title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1); // Handle potential NULL in Title
                                string frontImageFilePath = reader.IsDBNull(2) ? string.Empty : reader.GetString(2); // Handle potential NULL in FrontImageFilePath

                                Ad item = new Ad
                                {
                                    AdID = adID,
                                    Title = title,
                                    FrontImagePath = frontImageFilePath,
                                };

                                searchResults.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in SearchItemsAsync for search text: {ex}");
            }

            return searchResults;
        }

    }
}
