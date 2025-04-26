namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()


        {
            dataGridViewInventory = new DataGridView();
            comboBoxFilter = new ComboBox();
            buttonAddPlayer = new Button();
            buttonEditPlayer = new Button();
            buttonDeletePlayer = new Button();
            pictureBoxBlock = new PictureBox();
            buttonExportCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBlock).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventory.Location = new Point(12, 12);
            dataGridViewInventory.Name = "dataGridViewInventory";
            dataGridViewInventory.Size = new Size(400, 200);
            dataGridViewInventory.TabIndex = 0;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Location = new Point(12, 220);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(200, 23);
            comboBoxFilter.TabIndex = 1;
            comboBoxFilter.Text = "Filtrar por tipo/rareza";
            // 
            // buttonAddPlayer
            // 
            buttonAddPlayer.Location = new Point(420, 12);
            buttonAddPlayer.Name = "buttonAddPlayer";
            buttonAddPlayer.Size = new Size(100, 30);
            buttonAddPlayer.TabIndex = 2;
            buttonAddPlayer.Text = "Agregar";
            buttonAddPlayer.UseVisualStyleBackColor = true;
            // 
            // buttonEditPlayer
            // 
            buttonEditPlayer.Location = new Point(420, 48);
            buttonEditPlayer.Name = "buttonEditPlayer";
            buttonEditPlayer.Size = new Size(100, 30);
            buttonEditPlayer.TabIndex = 3;
            buttonEditPlayer.Text = "Modificar";
            buttonEditPlayer.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePlayer
            // 
            buttonDeletePlayer.Location = new Point(420, 84);
            buttonDeletePlayer.Name = "buttonDeletePlayer";
            buttonDeletePlayer.Size = new Size(100, 30);
            buttonDeletePlayer.TabIndex = 4;
            buttonDeletePlayer.Text = "Eliminar";
            buttonDeletePlayer.UseVisualStyleBackColor = true;
            // 
            // pictureBoxBlock
            // 
            pictureBoxBlock.Location = new Point(420, 120);
            pictureBoxBlock.Name = "pictureBoxBlock";
            pictureBoxBlock.Size = new Size(100, 100);
            pictureBoxBlock.TabIndex = 5;
            pictureBoxBlock.TabStop = false;
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Location = new Point(420, 230);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(100, 30);
            buttonExportCSV.TabIndex = 6;
            buttonExportCSV.Text = "Exportar CSV";
            buttonExportCSV.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 271);
            Controls.Add(buttonExportCSV);
            Controls.Add(pictureBoxBlock);
            Controls.Add(buttonDeletePlayer);
            Controls.Add(buttonEditPlayer);
            Controls.Add(buttonAddPlayer);
            Controls.Add(comboBoxFilter);
            Controls.Add(dataGridViewInventory);
            Name = "Form1";
            Text = "Gestión de Jugadores e Inventario";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBlock).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Button buttonEditPlayer;
        private System.Windows.Forms.Button buttonDeletePlayer;
        private System.Windows.Forms.PictureBox pictureBoxBlock;
        private System.Windows.Forms.Button buttonExportCSV;
    }
}
