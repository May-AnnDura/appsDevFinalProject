namespace OnlineBookstore
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            searchBtn = new Button();
            dataGridView1 = new DataGridView();
            addBtn = new Button();
            dataGridView2 = new DataGridView();
            label6 = new Label();
            cancelBtn = new Button();
            label10 = new Label();
            label11 = new Label();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 22);
            label1.Name = "label1";
            label1.Size = new Size(132, 30);
            label1.TabIndex = 0;
            label1.Text = "E-Bookstore";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 77);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Book Title";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 127);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "Author";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(413, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(98, 119);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(413, 23);
            textBox2.TabIndex = 6;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 192);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 7;
            label4.Text = "Quantity";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(98, 184);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(80, 23);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(812, 184);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 9;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 213);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(856, 253);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(812, 472);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 17;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(935, 119);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(336, 347);
            dataGridView2.TabIndex = 19;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(935, 79);
            label6.Name = "label6";
            label6.Size = new Size(102, 21);
            label6.TabIndex = 20;
            label6.Text = "Order Details";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(1185, 472);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(86, 23);
            cancelBtn.TabIndex = 21;
            cancelBtn.Text = "Cancel Order";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(98, 95);
            label10.Name = "label10";
            label10.Size = new Size(10, 15);
            label10.TabIndex = 26;
            label10.Text = " ";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(98, 145);
            label11.Name = "label11";
            label11.Size = new Size(10, 15);
            label11.TabIndex = 27;
            label11.Text = " ";
            label11.Click += label11_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(731, 184);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 28;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 528);
            Controls.Add(backBtn);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(cancelBtn);
            Controls.Add(label6);
            Controls.Add(dataGridView2);
            Controls.Add(addBtn);
            Controls.Add(dataGridView1);
            Controls.Add(searchBtn);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Button searchBtn;
        private DataGridView dataGridView1;
        private Button addBtn;
        private DataGridView dataGridView2;
        private Label label6;
        private Button cancelBtn;
        private Label label10;
        private Label label11;
        private Button backBtn;
    }
}
