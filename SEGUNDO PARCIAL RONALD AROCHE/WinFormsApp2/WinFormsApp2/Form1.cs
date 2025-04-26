using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private DataTable inventoryTable;
        private string connectionString = "Server=PC-GAMING-RAAS\\SQLEXPRESS;Database=BDPARCIAL2;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            LoadInventoryFromDatabase();
            BindEvents();
        }

        private void LoadInventoryFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    //PARA MOSTRAR UNA TABLA ABAJO TIENES QUE DESCOMENTAR EL CODIGO QUE QUIERAS VER 
                    connection.Open();
                    string query = "SELECT Nombre, Tipo, Rareza, Imagen FROM Bloques";
                    //string query = "SELECT Jugador, Bloque, Cantidad,Imagen FROM Inventario";
                    //string query = "SELECT Nombre, Nivel, Fechacreacion, Imagen FROM Jugadores";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    inventoryTable = new DataTable();
                    adapter.Fill(inventoryTable);

                    dataGridViewInventory.DataSource = inventoryTable;

                    // Configurar ComboBox para filtrar
                    comboBoxFilter.Items.AddRange(new string[] { "Todos", "Común", "Raro", "Épico" });
                    comboBoxFilter.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}");
                }
            }
        }

        private void BindEvents()
        {
            buttonAddPlayer.Click += ButtonAddPlayer_Click;
            buttonEditPlayer.Click += ButtonEditPlayer_Click;
            buttonDeletePlayer.Click += ButtonDeletePlayer_Click;
            comboBoxFilter.SelectedIndexChanged += ComboBoxFilter_SelectedIndexChanged;
            buttonExportCSV.Click += ButtonExportCSV_Click;
            dataGridViewInventory.SelectionChanged += DataGridViewInventory_SelectionChanged;
        }

        private void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Inventario (Nombre, Tipo, Rareza, Imagen) VALUES (@Nombre, @Tipo, @Rareza, @Imagen)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", "Nuevo Bloque");
                    command.Parameters.AddWithValue("@Tipo", "Material");
                    command.Parameters.AddWithValue("@Rareza", "Común");
                    command.Parameters.AddWithValue("@Imagen", "default.png");
                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro agregado correctamente.");
                    LoadInventoryFromDatabase(); // Recargar los datos
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el registro: {ex.Message}");
                }
            }
        }

        private void ButtonEditPlayer_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var row = dataGridViewInventory.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Inventario SET Nombre = @Nombre, Rareza = @Rareza WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Nombre", "Bloque Modificado");
                        command.Parameters.AddWithValue("@Rareza", "Épico");
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro modificado correctamente.");
                        LoadInventoryFromDatabase(); // Recargar los datos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar el registro: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
            }
        }

        private void ButtonDeletePlayer_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var row = dataGridViewInventory.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["ID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Inventario WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro eliminado correctamente.");
                        LoadInventoryFromDatabase(); // Recargar los datos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el registro: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBoxFilter.SelectedItem.ToString();
            if (filter == "Todos")
            {
                (dataGridViewInventory.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridViewInventory.DataSource as DataTable).DefaultView.RowFilter = $"Rareza = '{filter}'";
            }
        }

        private void ButtonExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                Title = "Guardar Inventario"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < inventoryTable.Columns.Count; i++)
                    {
                        writer.Write(inventoryTable.Columns[i].ColumnName);
                        if (i < inventoryTable.Columns.Count - 1) writer.Write(",");
                    }
                    writer.WriteLine();

                    foreach (DataRow row in inventoryTable.Rows)
                    {
                        for (int i = 0; i < inventoryTable.Columns.Count; i++)
                        {
                            writer.Write(row[i].ToString());
                            if (i < inventoryTable.Columns.Count - 1) writer.Write(",");
                        }
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Inventario exportado correctamente.");
            }
        }

        private void DataGridViewInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var row = dataGridViewInventory.SelectedRows[0];
                string imagePath = row.Cells["Imagen"].Value.ToString();

                try
                {
                    pictureBoxBlock.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    pictureBoxBlock.Image = null;
                    MessageBox.Show("No se pudo cargar la imagen.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
