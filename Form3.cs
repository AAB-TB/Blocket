using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocket
{
    public partial class Form3 : Form
    {
        string connectionString = Configuration.GetConnectionString();

        Ad selectedItem;
        public Form3(int selectedItemID)
        {
            InitializeComponent();

            LoadCollectionItemDetails(selectedItemID);


        }
        private void LoadCollectionItemDetails(int selectedItemID)
        {
            // Retrieve the selected collection item details
            selectedItem = RetrieveCollectionItemDetailsFromDatabase(selectedItemID);

            // Check if a valid collection item was found
            if (selectedItem != null)
            {
                itemTitle.Text = selectedItem.Title;
                itemDescription.Text = selectedItem.Description;
                txtPrice.Text = selectedItem.Price.ToString();

                // Load front and back images from file paths
                if (!string.IsNullOrEmpty(selectedItem.FrontImagePath))
                {
                    frontImagePictureBox.Image = Image.FromFile(selectedItem.FrontImagePath);
                }
                if (!string.IsNullOrEmpty(selectedItem.SecondImagePath))
                {
                    backImagePictureBox.Image = Image.FromFile(selectedItem.SecondImagePath);
                }

            }
            else
            {
                MessageBox.Show("An error occurred in the LoadCollectionItemDetails method");
            }
        }



        private Ad RetrieveCollectionItemDetailsFromDatabase(int adID)
        {
            string query = @"
        SELECT AdID, Title, Description, Price, CategoryID, FrontImagePath, SecondImagePath
        FROM Ads
        WHERE AdID = @AdID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AdID", adID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Ad ad = new Ad
                            {
                                AdID = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Price = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                                CategoryID = reader.GetInt32(4),
                                FrontImagePath = reader.IsDBNull(5) ? null : reader.GetString(5),
                                SecondImagePath = reader.IsDBNull(6) ? null : reader.GetString(6),
                            };

                            return ad;
                        }
                        else
                        {
                            // Handle the case where no matching ad is found, e.g., display an error message or return null.
                            MessageBox.Show($"Ad with ID {adID} not found in the database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any other errors here.
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return null;
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

        private void updateItemBtn_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                int id = (int)selectedItem.AdID;
                Form2 form2 = new Form2(id); // Pass the ID to Form2
                form2.Show();
                this.Hide();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("No advertisement is selected for deletion.");
                return;
            }

            // Confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this advertisement?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteAdvertisement(selectedItem.AdID);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete the advertisement. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private async void DeleteAdvertisement(int? adID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Delete the advertisement
                        string deleteAdQuery = "DELETE FROM Ads WHERE AdID = @AdID";
                        using (SqlCommand deleteAdCmd = new SqlCommand(deleteAdQuery, connection, transaction))
                        {
                            deleteAdCmd.Parameters.AddWithValue("@AdID", adID);
                            await deleteAdCmd.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                        MessageBox.Show("Advertisement deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw; // Re-throw the exception to handle it further up the call stack if needed.
                    }
                }
            }
        }
        private void ClearForm()
        {
            // Clear the text in textboxes
            itemTitle.Text = string.Empty;
            itemDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;

            // Clear the images in PictureBox controls
            frontImagePictureBox.Image = null;
            backImagePictureBox.Image = null;
        }

    }
}