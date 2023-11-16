namespace Blocket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            exitBtn = new Button();
            addItemsBtn = new Button();
            hmeBtn = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            suggestionsListBox = new ListBox();
            searchtextbox = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(exitBtn);
            panel1.Controls.Add(addItemsBtn);
            panel1.Controls.Add(hmeBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 689);
            panel1.TabIndex = 0;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.WhiteSmoke;
            exitBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBtn.ForeColor = Color.DarkGreen;
            exitBtn.Location = new Point(15, 541);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(239, 53);
            exitBtn.TabIndex = 3;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // addItemsBtn
            // 
            addItemsBtn.BackColor = Color.WhiteSmoke;
            addItemsBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addItemsBtn.ForeColor = Color.DarkGreen;
            addItemsBtn.Location = new Point(15, 389);
            addItemsBtn.Name = "addItemsBtn";
            addItemsBtn.Size = new Size(239, 53);
            addItemsBtn.TabIndex = 2;
            addItemsBtn.Text = "Add New Items";
            addItemsBtn.UseVisualStyleBackColor = false;
            addItemsBtn.Click += addItemsBtn_Click;
            // 
            // hmeBtn
            // 
            hmeBtn.BackColor = Color.WhiteSmoke;
            hmeBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hmeBtn.ForeColor = Color.DarkGreen;
            hmeBtn.Location = new Point(15, 259);
            hmeBtn.Name = "hmeBtn";
            hmeBtn.Size = new Size(239, 53);
            hmeBtn.TabIndex = 1;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.OrangeRed;
            label1.Location = new Point(633, 29);
            label1.Name = "label1";
            label1.Size = new Size(249, 41);
            label1.TabIndex = 3;
            label1.Text = "AAB-TB: Blocket";
            // 
            // suggestionsListBox
            // 
            suggestionsListBox.BackColor = SystemColors.GradientActiveCaption;
            suggestionsListBox.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            suggestionsListBox.FormattingEnabled = true;
            suggestionsListBox.ItemHeight = 37;
            suggestionsListBox.Location = new Point(362, 133);
            suggestionsListBox.Name = "suggestionsListBox";
            suggestionsListBox.ScrollAlwaysVisible = true;
            suggestionsListBox.Size = new Size(863, 78);
            suggestionsListBox.TabIndex = 5;
            suggestionsListBox.Visible = false;
            // 
            // searchtextbox
            // 
            searchtextbox.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            searchtextbox.ForeColor = Color.DarkGreen;
            searchtextbox.Location = new Point(362, 80);
            searchtextbox.Name = "searchtextbox";
            searchtextbox.PlaceholderText = "Search By Category or Item Name";
            searchtextbox.Size = new Size(863, 47);
            searchtextbox.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(308, 219);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(978, 482);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 724);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(suggestionsListBox);
            Controls.Add(searchtextbox);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button hmeBtn;
        private PictureBox pictureBox1;
        private Button addItemsBtn;
        private Button exitBtn;
        private Label label1;
        private ListBox suggestionsListBox;
        private TextBox searchtextbox;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
