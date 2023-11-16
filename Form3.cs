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
        DataAccess access = new DataAccess();

        Ad selectedItem;
        public Form3(int selectedItemID)
        {
            InitializeComponent();

            LoadCollectionItemDetails(selectedItemID);


        }
        private void LoadCollectionItemDetails(int selectedItemID)
        {
            // Retrieve the selected collection item details
            selectedItem = access.RetrieveCollectionItemDetailsFromDatabase(selectedItemID);

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
                    access.DeleteAdvertisement(selectedItem.AdID);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete the advertisement. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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