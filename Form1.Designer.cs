namespace WinFormsApp1
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            navigacniPanel = new Panel();
            labelBody = new Label();
            labelSkore = new Label();
            listView1 = new ListView();
            button1 = new Button();
            hraciPanel = new Panel();
            navigacniPanel.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // navigacniPanel
            // 
            navigacniPanel.BackColor = SystemColors.InactiveCaption;
            navigacniPanel.Controls.Add(labelBody);
            navigacniPanel.Controls.Add(labelSkore);
            navigacniPanel.Controls.Add(listView1);
            navigacniPanel.Controls.Add(button1);
            navigacniPanel.Location = new Point(695, 16);
            navigacniPanel.Name = "navigacniPanel";
            navigacniPanel.Size = new Size(413, 549);
            navigacniPanel.TabIndex = 0;
            // 
            // labelBody
            // 
            labelBody.AutoSize = true;
            labelBody.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelBody.Location = new Point(129, 288);
            labelBody.Name = "labelBody";
            labelBody.Size = new Size(31, 20);
            labelBody.TabIndex = 3;
            labelBody.Text = "0 b";
            // 
            // labelSkore
            // 
            labelSkore.AutoSize = true;
            labelSkore.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelSkore.Location = new Point(36, 288);
            labelSkore.Name = "labelSkore";
            labelSkore.Size = new Size(92, 38);
            labelSkore.TabIndex = 2;
            labelSkore.Text = "Skóre";
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 50);
            listView1.Name = "listView1";
            listView1.Size = new Size(390, 194);
            listView1.TabIndex = 1;
            listView1.TabStop = false;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            listView1.KeyDown += listView1_KeyDown;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(51, 392);
            button1.Name = "button1";
            button1.Size = new Size(157, 29);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "play game";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // hraciPanel
            // 
            hraciPanel.BackColor = SystemColors.ActiveCaption;
            hraciPanel.Location = new Point(88, 16);
            hraciPanel.Name = "hraciPanel";
            hraciPanel.Size = new Size(503, 584);
            hraciPanel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 624);
            Controls.Add(hraciPanel);
            Controls.Add(navigacniPanel);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;
            navigacniPanel.ResumeLayout(false);
            navigacniPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel navigacniPanel;
        public Panel hraciPanel;
        private Button button1;
        private ListView listView1;
        private Label labelSkore;
        private Label labelBody;
    }
}
