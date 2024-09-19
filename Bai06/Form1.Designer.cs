namespace Bai06
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			button1 = new Button();
			btnReport = new Button();
			txtQuantity = new TextBox();
			cbbSpecies = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			btnAdd = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(69, 176);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(659, 253);
			dataGridView1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(491, 22);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 2;
			button1.Text = "Voice";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// btnReport
			// 
			btnReport.Location = new Point(379, 22);
			btnReport.Name = "btnReport";
			btnReport.Size = new Size(94, 29);
			btnReport.TabIndex = 3;
			btnReport.Text = "Thống kê";
			btnReport.UseVisualStyleBackColor = true;
			btnReport.Click += btnReport_Click;
			// 
			// txtQuantity
			// 
			txtQuantity.Location = new Point(87, 68);
			txtQuantity.Name = "txtQuantity";
			txtQuantity.Size = new Size(151, 27);
			txtQuantity.TabIndex = 4;
			// 
			// cbbSpecies
			// 
			cbbSpecies.FormattingEnabled = true;
			cbbSpecies.Location = new Point(87, 22);
			cbbSpecies.Name = "cbbSpecies";
			cbbSpecies.Size = new Size(151, 28);
			cbbSpecies.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 71);
			label1.Name = "label1";
			label1.Size = new Size(69, 20);
			label1.TabIndex = 6;
			label1.Text = "Số lượng";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 26);
			label2.Name = "label2";
			label2.Size = new Size(37, 20);
			label2.TabIndex = 7;
			label2.Text = "Loại";
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(87, 114);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(94, 29);
			btnAdd.TabIndex = 8;
			btnAdd.Text = "Add";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnAdd);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(cbbSpecies);
			Controls.Add(txtQuantity);
			Controls.Add(btnReport);
			Controls.Add(button1);
			Controls.Add(dataGridView1);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
        private Button button1;
        private Button btnReport;
		private TextBox txtQuantity;
		private ComboBox cbbSpecies;
		private Label label1;
		private Label label2;
		private Button btnAdd;
	}
}
