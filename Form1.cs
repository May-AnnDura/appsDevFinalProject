using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Net;

namespace OnlineBookstore
{
    public partial class Form1 : Form
    {
        string connectionString = "data source=HP;initial catalog=BookstoreDBS;trusted_connection=true";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooksData();
            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";

            DataTable dataTable = new DataTable();
            string query = @"SELECT O.ORDER_ID, B.TITLE, O.QUANTITY, O.TOTAL_PRICE, O.BOOK_ID FROM ORDERS O JOIN BOOKS B ON O.BOOK_ID = B.BOOK_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
            }
        }

        private void LoadBooksData()
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";

            string query = "SELECT * FROM BOOKS";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(dataTable);
            }


            if (dataTable.Rows.Count > 0)
            {
                dataGridView1.Refresh();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.DataSource = dataTable;

            }
            else
            {
                MessageBox.Show("No data found.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string titleInput = textBox1.Text.Trim();
            string authorInput = textBox2.Text.Trim();

            label10.Text = "";
            label11.Text = "";

            if (string.IsNullOrEmpty(titleInput) && string.IsNullOrEmpty(authorInput))
            {
                MessageBox.Show("Fill in the fields!");
            }

            else if (!IsTitleLengthValid(titleInput))
            {
                { label10.Text = "This field only has a maximum of 100 characters."; label10.Refresh(); }
            }

            else if (!IsAuthorLengthValid(authorInput))
            {
                { label11.Text = "This field only has a maximum of 50 characters."; label11.Refresh(); }
            }

            else
            {
                MessageBox.Show("Valid Title and Author Length!");
                SearchDatabase(titleInput, authorInput);
            }
        }

        private void SearchDatabase(string titleKeyword, string authorKeyword)
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";

            string query = "SELECT * FROM BOOKS WHERE (TITLE LIKE @titleKeyword AND AUTHOR LIKE @authorKeyword)";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@titleKeyword", "%" + titleKeyword + "%");
                    command.Parameters.AddWithValue("@authorkeyword", "%" + authorKeyword + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable results = new DataTable();
                    adapter.Fill(results);

                    if (results.Rows.Count == 0)
                    {
                        MessageBox.Show("No books found matching your search criteria.");
                    }
                    else
                    {
                        dataGridView1.DataSource = results;
                    }
                }
            }

        }
        private bool IsTitleLengthValid(string input)
        {
            return input.Length <= 100;
        }

        private bool IsAuthorLengthValid(string input)
        {
            return input.Length <= 50;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBookStock(int bookID, int newStock)
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";
            string updateQuery = "UPDATE BOOKS SET STOCK = @STOCK WHERE BOOK_ID = @BOOK_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@STOCK", newStock);
                    command.Parameters.AddWithValue("@BOOK_ID", bookID);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";
            string qtyText = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(qtyText) || !int.TryParse(qtyText, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid input for Quantity!");
                return;
            }

            if (selectedBookID == 0)
            {
                MessageBox.Show("Select a book first to add an order.");
                return;
            }

            if (quantity > selectedBookStock)
            {
                MessageBox.Show("Insufficient stock!");
                return;
            }

            decimal totalPrice = selectedBookPrice * quantity;

            string query = "INSERT INTO ORDERS (BOOK_ID, QUANTITY, TOTAL_PRICE) VALUES (@BOOK_ID, @QUANTITY, @TOTAL_PRICE)";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BOOK_ID", selectedBookID);
                    command.Parameters.AddWithValue("@QUANTITY", quantity);
                    command.Parameters.AddWithValue("TOTAL_PRICE", totalPrice);

                    int rowsAffected = command.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order added successfully!");
                        selectedBookStock -= quantity;
                        UpdateBookStock(selectedBookID, selectedBookStock);
                        LoadBooksData();
                        LoadOrdersData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add order.");
                    }

                }
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            LoadBooksData();
        }

        private int selectedBookID = 0;
        private decimal selectedBookPrice = 0;
        private int selectedBookStock = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];


                selectedBookStock = Convert.ToInt32(selectedRow.Cells["STOCK"].Value);

                selectedBookID = Convert.ToInt32(selectedRow.Cells["BOOK_ID"].Value);
                selectedBookPrice = Convert.ToDecimal(selectedRow.Cells["PRICE"].Value);
                selectedBookStock = Convert.ToInt32(selectedRow.Cells["STOCK"].Value);
            }

        }

        private void UpdateBookStock2(int bookID, int qtyToAdd)
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";
            string updateQuery = "UPDATE BOOKS SET STOCK = STOCK + @QUANTITY WHERE BOOK_ID = @BOOK_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@BOOK_ID", bookID);
                    command.Parameters.AddWithValue("@QUANTITY", qtyToAdd);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void CancelOrder(int orderID, int bookID, int quantity)
        {
            string connectionString = "data source=HP;initial catalog=BookstoreDBS;TrustServerCertificate = true;trusted_connection=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM ORDERS WHERE ORDER_ID = @ORDER_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ORDER_ID", orderID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order cancelled successfully.");

                        UpdateBookStock2(bookID, quantity);

                        //LoadBooksData();
                        //LoadOrdersData();
                    }

                    else
                    {
                        MessageBox.Show("Failed to cancel the order.");
                    }

                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView2.CurrentRow;

                int selectedOrderID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ORDER_ID"].Value);
                int selectedBookID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["BOOK_ID"].Value);
                int quantity = Convert.ToInt32(dataGridView2.CurrentRow.Cells["QUANTITY"].Value);

                CancelOrder(selectedOrderID, selectedBookID, quantity);

                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);


                LoadBooksData();
                LoadOrdersData();
            }
            else
            {
                MessageBox.Show("Select an order to cancel.");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

       
            }
        }


    }
}
