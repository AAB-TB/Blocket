using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocket
{
    public partial class Form2 : Form
    {
        string connectionString = Configuration.GetConnectionString();
        private OpenFileDialog frontImageOpenFileDialog = new OpenFileDialog();
        private OpenFileDialog backImageOpenFileDialog = new OpenFileDialog();
        string frontImagefilePath;
        string backImagefilePath;


        private int selectedItem;

        public Form2()
        {
            InitializeComponent();
            LoadCategories();
        }
        public Form2(int selectedItem)
        {
            InitializeComponent();
            LoadCategories();
            this.selectedItem = selectedItem;
            LoadItemDetails(selectedItem);
        }
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getCategoryQuery = "SELECT CategoryID, CategoryName FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(getCategoryQuery, connection))
                    {
                        DataTable categoryDataTable = new DataTable();
                        categoryDataTable.Load(cmd.ExecuteReader());

                        categoryComboBox.DataSource = categoryDataTable;
                        categoryComboBox.DisplayMember = "CategoryName";
                        categoryComboBox.ValueMember = "CategoryID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadCategories{ex}");
            }
        }
        private void LoadItemDetails(int selectedItem)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getItemQuery = "SELECT * FROM Ads WHERE AdID = @AdID";

                    using (SqlCommand cmd = new SqlCommand(getItemQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@AdID", selectedItem);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtItemName.Text = reader["Title"].ToString();

                            descriptionTextBox.Text = reader["Description"].ToString();

                            txtPrice.Text = reader["Price"].ToString();

                            // Set the selected category in the ComboBox
                            categoryComboBox.SelectedValue = reader["CategoryID"];

                            // Load front and back images from file paths
                            string frontImageFPath = reader["FrontImagePath"].ToString();
                            string backImageFPath = reader["SecondImagePath"].ToString();


                            if (!string.IsNullOrEmpty(frontImageFPath))
                            {
                                frontImagePictureBox.Image = Image.FromFile(frontImageFPath);
                                frontImagefilePath = frontImageFPath; // Set the image path variable.
                            }

                            if (!string.IsNullOrEmpty(backImageFPath))
                            {
                                backImagePictureBox.Image = Image.FromFile(backImageFPath);
                                backImagefilePath = backImageFPath; // Set the image path variable.
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadItemDetails{ex}");
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

        private void frontImagePictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                frontImageOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico";
                if (frontImageOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    frontImagefilePath = frontImageOpenFileDialog.FileName;
                    frontImagePictureBox.Image = Image.FromFile(frontImagefilePath);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"frontImagePictureBox_Click{ex}");
            }
        }

        private void backImagePictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                backImageOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico";
                if (backImageOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    backImagefilePath = backImageOpenFileDialog.FileName;
                    backImagePictureBox.Image = Image.FromFile(backImagefilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"backImagePictureBox_Click{ex}");
            }
        }

        private void nycategoriSave_Click(object sender, EventArgs e)
        {
            string categoryName = nycategorytxtbox.Text; // Get the category name from the TextBox

            if (!string.IsNullOrEmpty(categoryName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string insertCategoryQuery = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName); SELECT SCOPE_IDENTITY()";

                        using (SqlCommand cmd = new SqlCommand(insertCategoryQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Category Saved Successfully!");
                                nycategorytxtbox.Text = ""; // Clear the TextBox
                                LoadCategories();
                            }
                            else
                            {
                                MessageBox.Show("Failed to save the category.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Please enter a category name.");
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter an item name.");
                return false;
            }


            if (categoryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a description.");
                return false;
            }



            return true;
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            if (ValidateFields()) // Custom method to validate mandatory fields.
            {
                try
                {
                    using (connection)
                    {
                        await connection.OpenAsync();

                        // Prepare the SQL command with parameters to prevent SQL injection.
                        string sql = @"INSERT INTO Ads (Title, Description, Price, FrontImagePath, SecondImagePath, CategoryID) 
                               VALUES (@Title, @Description, @Price, @FrontImagePath, @SecondImagePath, @CategoryID);";

                        using SqlCommand command = new SqlCommand(sql, connection);

                        // Set parameter values from your controls.
                        command.Parameters.AddWithValue("@Title", txtItemName.Text);
                        command.Parameters.AddWithValue("@Description", descriptionTextBox.Text);
                        command.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text)); // Assuming txtPrice is a TextBox for the price.
                        command.Parameters.AddWithValue("@CategoryID", categoryComboBox.SelectedValue); // Assuming your ComboBox is data-bound.

                        if (frontImagefilePath != null)
                        {
                            command.Parameters.AddWithValue("@FrontImagePath", frontImagefilePath);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@FrontImagePath", DBNull.Value);
                        }

                        if (backImagefilePath != null)
                        {
                            command.Parameters.AddWithValue("@SecondImagePath", backImagefilePath);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SecondImagePath", DBNull.Value);
                        }

                        await command.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Item added successfully!");
                    ClearForm(); // Custom method to clear fields.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all mandatory fields.");
            }
        }
        private void ClearForm()
        {
            // Clear the text in textboxes
            txtItemName.Text = string.Empty;

            frontImagePictureBox.Text = string.Empty;
            frontImagePictureBox.Tag = null;
            backImagePictureBox.Text = null;
            backImagePictureBox.Tag = null;
            descriptionTextBox.Text = string.Empty;
            nycategorytxtbox.Text = string.Empty;

            categoryComboBox.SelectedIndex = -1;


        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ValidateFields()) // Custom method to validate mandatory fields.
                {
                    try
                    {
                        await connection.OpenAsync();

                        // Prepare the SQL command with parameters to prevent SQL injection.
                        string sql = @" UPDATE Ads SET Title = @Title,
                                                        Description = @Description,
                                                        Price = @Price,
                                                        FrontImagePath = @FrontImagePath,
                                                        SecondImagePath = @SecondImagePath,
                                                        CategoryID = @CategoryID
                                                    WHERE AdID = @AdID;";
                                                                        

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@AdID", selectedItem);
                            command.Parameters.AddWithValue("@Title", txtItemName.Text);
                            command.Parameters.AddWithValue("@Description", descriptionTextBox.Text);
                            command.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                            command.Parameters.AddWithValue("@CategoryID", categoryComboBox.SelectedValue);

                            if (frontImagefilePath != null)
                            {
                                command.Parameters.AddWithValue("@FrontImagePath", frontImagefilePath);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@FrontImagePath", DBNull.Value);
                            }

                            if (backImagefilePath != null)
                            {
                                command.Parameters.AddWithValue("@SecondImagePath", backImagefilePath);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@SecondImagePath", DBNull.Value);
                            }

                            await command.ExecuteNonQueryAsync();
                        }
                        MessageBox.Show("Item updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all mandatory fields.");
                }
            }

        }
    }
}
