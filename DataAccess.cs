using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blocket
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess()
        {
            this.connectionString = Configuration.GetConnectionString();
        }

        public async Task<List<Ad>> RetrieveDataFromDatabaseAsync()
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

        public Ad RetrieveCollectionItemDetailsFromDatabase(int adID)
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


        public async Task<List<string>> GetAutocompleteSuggestionsAsync(string searchText)
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

        public async Task<List<Ad>> SearchItemsAsync(string searchText)
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
        public async Task DeleteAdvertisement(int? adID)
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
    }
}
