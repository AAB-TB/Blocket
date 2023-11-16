namespace Blocket
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            panel1 = new Panel();
            deleteBtn = new Button();
            pictureBox1 = new PictureBox();
            exitBtn = new Button();
            hmeBtn = new Button();
            updateItemBtn = new Button();
            itemTitle = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            frontImagePictureBox = new PictureBox();
            tabPage2 = new TabPage();
            backImagePictureBox = new PictureBox();
            itemDescription = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
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
            panel1.Controls.Add(deleteBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(exitBtn);
            panel1.Controls.Add(hmeBtn);
            panel1.Controls.Add(updateItemBtn);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 689);
            panel1.TabIndex = 1;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.WhiteSmoke;
            deleteBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            deleteBtn.ForeColor = Color.DarkGreen;
            deleteBtn.Location = new Point(15, 459);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(239, 47);
            deleteBtn.TabIndex = 10;
            deleteBtn.Text = "Delete Item";
            deleteBtn.UseVisualStyleBackColor = false;
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
            // exitBtn
            // 
            exitBtn.BackColor = Color.WhiteSmoke;
            exitBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            exitBtn.ForeColor = Color.DarkGreen;
            exitBtn.Location = new Point(15, 571);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(239, 47);
            exitBtn.TabIndex = 9;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // hmeBtn
            // 
            hmeBtn.BackColor = Color.WhiteSmoke;
            hmeBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            hmeBtn.ForeColor = Color.DarkGreen;
            hmeBtn.Location = new Point(15, 242);
            hmeBtn.Name = "hmeBtn";
            hmeBtn.Size = new Size(239, 47);
            hmeBtn.TabIndex = 7;
            hmeBtn.Text = "Home";
            hmeBtn.UseVisualStyleBackColor = false;
            hmeBtn.Click += hmeBtn_Click;
            // 
            // updateItemBtn
            // 
            updateItemBtn.BackColor = Color.WhiteSmoke;
            updateItemBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            updateItemBtn.ForeColor = Color.DarkGreen;
            updateItemBtn.Location = new Point(15, 342);
            updateItemBtn.Name = "updateItemBtn";
            updateItemBtn.Size = new Size(239, 47);
            updateItemBtn.TabIndex = 8;
            updateItemBtn.Text = "Update Item";
            updateItemBtn.UseVisualStyleBackColor = false;
            updateItemBtn.Click += updateItemBtn_Click;
            // 
            // itemTitle
            // 
            itemTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            itemTitle.ForeColor = Color.DarkGreen;
            itemTitle.Location = new Point(559, 28);
            itemTitle.Name = "itemTitle";
            itemTitle.PlaceholderText = "Föremål Namn";
            itemTitle.Size = new Size(415, 38);
            itemTitle.TabIndex = 16;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(846, 105);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(411, 479);
            tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(frontImagePictureBox);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(403, 443);
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
            frontImagePictureBox.Size = new Size(397, 437);
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
            tabPage2.Size = new Size(403, 443);
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
            backImagePictureBox.Size = new Size(397, 437);
            backImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            backImagePictureBox.TabIndex = 21;
            backImagePictureBox.TabStop = false;
            // 
            // itemDescription
            // 
            itemDescription.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            itemDescription.ForeColor = Color.DarkGreen;
            itemDescription.Location = new Point(309, 134);
            itemDescription.Multiline = true;
            itemDescription.Name = "itemDescription";
            itemDescription.PlaceholderText = "Description";
            itemDescription.ScrollBars = ScrollBars.Vertical;
            itemDescription.Size = new Size(502, 450);
            itemDescription.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(575, 645);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 37;
            label1.Text = "Item Price";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.DarkGreen;
            textBox1.Location = new Point(773, 642);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Item Price";
            textBox1.Size = new Size(258, 38);
            textBox1.TabIndex = 36;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 724);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(itemDescription);
            Controls.Add(tabControl1);
            Controls.Add(itemTitle);
            Controls.Add(panel1);
            Name = "Form3";
            Text = "Form3";
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
        private Button deleteBtn;
        private Button exitBtn;
        private Button hmeBtn;
        private Button updateItemBtn;
        private TextBox itemTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private PictureBox frontImagePictureBox;
        private TabPage tabPage2;
        private PictureBox backImagePictureBox;
        private TextBox itemDescription;
        private Label label1;
        private TextBox textBox1;
    }
}