using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bai06
{
	public partial class Form1 : Form
	{


		private string connectionString = "Data Source=.;Initial Catalog=FarmManagementDB;Integrated Security=True;";
		public Form1()
		{
			InitializeComponent();

			cbbSpecies.Items.Add("Cừu");
			cbbSpecies.Items.Add("Bò");
			cbbSpecies.Items.Add("Dê");
			cbbSpecies.SelectedIndex = 0;

			// Tải dữ liệu vào DataGridView
			LoadDataIntoDataGridView();
		}
		private void btnLoadData_Click(object sender, EventArgs e)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT * FROM Animals";

				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				DataTable dataTable = new DataTable();

				adapter.Fill(dataTable);

				dataGridView1.DataSource = dataTable;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string sounds = "";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string query = "SELECT Voice, Count FROM Animals WHERE Count > 0";

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							//sounds += reader["Voice"].ToString() + " ";
							string voice = reader["Voice"].ToString() + "";
							int count = (int)reader["Count"];

							// Tạo chuỗi tiếng kêu với số lượng tương ứng
							sounds += string.Join(" ", Enumerable.Repeat(voice, count)) + " ";
						}
					}
				}

				connection.Close();
			}

			MessageBox.Show("Tiếng kêu trong nông trại khi tất cả gia súc đều đói: " + sounds);
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
			string report = "Thông tin sau mỗi lần sinh và lược cho sữa của tất cả gia súc:\n";
			Random random = new Random(); // Để sinh số ngẫu nhiên

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Cập nhật số lượng con ngẫu nhiên và lượng sữa ngẫu nhiên cho từng gia súc
				string updateQuery = @"
            UPDATE Animals
            SET NumberOfOffspring = ROUND(RAND() * 5 + 1, 0), -- Số lượng con ngẫu nhiên từ 1 đến 5
                MilkProduced = CASE 
                                WHEN Name = 'Bò' THEN ROUND(RAND() * 20, 0) + 1  -- 1 đến 20 lít cho Bò
                                WHEN Name = 'Cừu' THEN ROUND(RAND() * 5, 0) + 1   -- 1 đến 5 lít cho Cừu
                                WHEN Name = 'Dê' THEN ROUND(RAND() * 10, 0) + 1   -- 1 đến 10 lít cho Dê
                                ELSE 0
                             END
        ";

				using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
				{
					updateCommand.ExecuteNonQuery();
				}

				// Tính tổng số lít sữa
				string selectQuery = @"
            SELECT Name, SUM(NumberOfOffspring) AS TotalCount, 
                   SUM(MilkProduced * NumberOfOffspring) AS TotalMilkProduced 
            FROM Animals 
            GROUP BY Name
        ";

				using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
				{
					using (SqlDataReader reader = selectCommand.ExecuteReader())
					{
						while (reader.Read())
						{
							string name = reader["Name"].ToString();
							int totalCount = Convert.ToInt32(reader["TotalCount"]);
							int totalMilk = Convert.ToInt32(reader["TotalMilkProduced"]);

							report += $"Loài {name}: Tổng số gia súc {totalCount}, Tổng số sữa {totalMilk} lít\n";
						}
					}
				}

				connection.Close();
			}

			MessageBox.Show(report, "Thống kê thông tin gia súc");
		}
		private void LoadDataIntoDataGridView()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "SELECT Name, Count FROM Animals";
				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				DataTable dataTable = new DataTable();
				adapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable;
				connection.Close();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string selectedSpecies = cbbSpecies.SelectedItem.ToString();

			// Lấy số lượng từ TextBox
			int quantity;
			if (int.TryParse(txtQuantity.Text, out quantity) && quantity > 0)
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Kiểm tra xem loài động vật đã có trong bảng chưa
					string queryCheck = "SELECT COUNT(*) FROM Animals WHERE Name = @name";
					using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
					{
						cmdCheck.Parameters.AddWithValue("@name", selectedSpecies);

						int count = (int)cmdCheck.ExecuteScalar();

						if (count > 0)
						{
							// Nếu loài đã có, cộng thêm số lượng
							string updateQuery = "UPDATE Animals SET Count = Count + @quantity WHERE Name = @name";
							using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
							{
								cmdUpdate.Parameters.AddWithValue("@quantity", quantity);
								cmdUpdate.Parameters.AddWithValue("@name", selectedSpecies);
								cmdUpdate.ExecuteNonQuery();
							}
						}
						else
						{
							// Nếu loài chưa có, thêm mới
							string insertQuery = "INSERT INTO Animals (Name, Voice, Count) VALUES (@name, @voice, @count)";
							using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connection))
							{
								// Giả định rằng tiếng kêu cho mỗi loài là cố định
								string voice = selectedSpecies == "Cừu" ? "Baa" :
											   selectedSpecies == "Bò" ? "Moo" :
											   "Meh"; // Dê

								cmdInsert.Parameters.AddWithValue("@name", selectedSpecies);
								cmdInsert.Parameters.AddWithValue("@voice", voice);
								cmdInsert.Parameters.AddWithValue("@count", quantity);
								cmdInsert.ExecuteNonQuery();
							}
						}
					}

					connection.Close();
				}

				// Cập nhật lại DataGridView sau khi thêm dữ liệu
				LoadDataIntoDataGridView();
			}
			else
			{
				MessageBox.Show("Vui lòng nhập số lượng hợp lệ!");
			}
		}
	}
}
