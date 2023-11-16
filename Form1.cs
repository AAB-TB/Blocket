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
        private readonly DataAccess DataAccess;
        DataAccess access = new DataAccess();
        public Form1()
        {
            InitializeComponent();
            Load += async (sender, e) => await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                List<Ad> collectionItemDataList = await access.RetrieveDataFromDatabaseAsync();

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
                List<string> suggestions = await access.GetAutocompleteSuggestionsAsync(searchText);

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
                List<Ad> searchResults = await access.SearchItemsAsync(selectedSuggestion);
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

        
    }
}
