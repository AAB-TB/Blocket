namespace Blocket
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            exitBtn = new Button();
            updateBtn = new Button();
            addBtn = new Button();
            hmeBtn = new Button();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            frontImagePictureBox = new PictureBox();
            tabPage2 = new TabPage();
            backImagePictureBox = new PictureBox();
            label4 = new Label();
            descriptionTextBox = new TextBox();
            categoryComboBox = new ComboBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            txtItemName = new TextBox();
            nycategoriSave = new Button();
            nycategorytxtbox = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)frontImagePictureBox).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(exitBtn);
            panel1.Controls.Add(updateBtn);
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(hmeBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 689);
            panel1.TabIndex = 1;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.WhiteSmoke;
            exitBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            exitBtn.ForeColor = Color.DarkGreen;
            exitBtn.Location = new Point(15, 528);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(239, 47);
            exitBtn.TabIndex = 8;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.WhiteSmoke;
            updateBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            updateBtn.ForeColor = Color.DarkGreen;
            updateBtn.Location = new Point(15, 437);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(239, 47);
            updateBtn.TabIndex = 7;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.WhiteSmoke;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            addBtn.ForeColor = Color.DarkGreen;
            addBtn.Location = new Point(15, 348);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(239, 47);
            addBtn.TabIndex = 6;
            addBtn.Text = "Save New Item";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // hmeBtn
            // 
            hmeBtn.BackColor = Color.WhiteSmoke;
            hmeBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            hmeBtn.ForeColor = Color.DarkGreen;
            hmeBtn.Location = new Point(15, 257);
            hmeBtn.Name = "hmeBtn";
            hmeBtn.Size = new Size(239, 47);
            hmeBtn.TabIndex = 5;
            hmeBtn.Text = "Home";
            hmeBtn.UseVisualStyleBackColor = false;
            hmeBtn.Click += hmeBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 189);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(316, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(411, 333);
            tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(frontImagePictureBox);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(403, 297);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Image 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // frontImagePictureBox
            // 
            frontImagePictureBox.BorderStyle = BorderStyle.Fixed3D;
            frontImagePictureBox.Dock = DockStyle.Fill;
            frontImagePictureBox.Location = new Point(3, 3);
            frontImagePictureBox.Name = "frontImagePictureBox";
            frontImagePictureBox.Size = new Size(397, 291);
            frontImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            frontImagePictureBox.TabIndex = 20;
            frontImagePictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(backImagePictureBox);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(403, 297);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Image 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // backImagePictureBox
            // 
            backImagePictureBox.BorderStyle = BorderStyle.Fixed3D;
            backImagePictureBox.Dock = DockStyle.Fill;
            backImagePictureBox.Location = new Point(3, 3);
            backImagePictureBox.Name = "backImagePictureBox";
            backImagePictureBox.Size = new Size(397, 291);
            backImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            backImagePictureBox.TabIndex = 21;
            backImagePictureBox.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(316, 376);
            label4.Name = "label4";
            label4.Size = new Size(193, 31);
            label4.TabIndex = 26;
            label4.Text = "Item Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            descriptionTextBox.ForeColor = Color.DarkGreen;
            descriptionTextBox.Location = new Point(316, 414);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.PlaceholderText = "Item Description";
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(970, 295);
            descriptionTextBox.TabIndex = 25;
            // 
            // categoryComboBox
            // 
            categoryComboBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            categoryComboBox.ForeColor = Color.DarkGreen;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(985, 196);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(258, 39);
            categoryComboBox.TabIndex = 36;
            categoryComboBox.Text = "Category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(787, 129);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 35;
            label1.Text = "Item Price";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.DarkGreen;
            textBox1.Location = new Point(985, 126);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Item Price";
            textBox1.Size = new Size(258, 38);
            textBox1.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(787, 75);
            label3.Name = "label3";
            label3.Size = new Size(132, 31);
            label3.TabIndex = 33;
            label3.Text = "Item Name";
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtItemName.ForeColor = Color.DarkGreen;
            txtItemName.Location = new Point(985, 72);
            txtItemName.Name = "txtItemName";
            txtItemName.PlaceholderText = "Item Name";
            txtItemName.Size = new Size(258, 38);
            txtItemName.TabIndex = 32;
            // 
            // nycategoriSave
            // 
            nycategoriSave.BackColor = Color.WhiteSmoke;
            nycategoriSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            nycategoriSave.ForeColor = Color.DarkGreen;
            nycategoriSave.Location = new Point(1077, 308);
            nycategoriSave.Name = "nycategoriSave";
            nycategoriSave.Size = new Size(166, 38);
            nycategoriSave.TabIndex = 38;
            nycategoriSave.Text = "Save";
            nycategoriSave.UseVisualStyleBackColor = false;
            // 
            // nycategorytxtbox
            // 
            nycategorytxtbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            nycategorytxtbox.ForeColor = Color.DarkGreen;
            nycategorytxtbox.Location = new Point(787, 308);
            nycategorytxtbox.Name = "nycategorytxtbox";
            nycategorytxtbox.PlaceholderText = "Lägg till Ny kategori";
            nycategorytxtbox.Size = new Size(258, 38);
            nycategorytxtbox.TabIndex = 37;
            nycategorytxtbox.Text = "Add New Category";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 724);
            Controls.Add(nycategoriSave);
            Controls.Add(nycategorytxtbox);
            Controls.Add(categoryComboBox);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txtItemName);
            Controls.Add(label4);
            Controls.Add(descriptionTextBox);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)frontImagePictureBox).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)backImagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button exitBtn;
        private Button updateBtn;
        private Button addBtn;
        private Button hmeBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private PictureBox frontImagePictureBox;
        private TabPage tabPage2;
        private PictureBox backImagePictureBox;
        private Label label4;
        private TextBox descriptionTextBox;
        private ComboBox categoryComboBox;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private TextBox txtItemName;
        private Button nycategoriSave;
        private TextBox nycategorytxtbox;
    }
}