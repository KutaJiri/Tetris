namespace WinFormsApp1
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
            label1 = new Label();
            labelPovzbuzujiciText = new Label();
            textBox1 = new TextBox();
            buttonHotovo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 113);
            label1.Name = "label1";
            label1.Size = new Size(346, 20);
            label1.TabIndex = 0;
            label1.Text = "   Zapiš si sem své  jméno ať víme jak jsi se umístil .";
            // 
            // labelPovzbuzujiciText
            // 
            labelPovzbuzujiciText.AutoSize = true;
            labelPovzbuzujiciText.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelPovzbuzujiciText.Location = new Point(126, 40);
            labelPovzbuzujiciText.Name = "labelPovzbuzujiciText";
            labelPovzbuzujiciText.Size = new Size(443, 38);
            labelPovzbuzujiciText.TabIndex = 1;
            labelPovzbuzujiciText.Text = "Perfektní skóre .   Jsi fakt dobrý.";
            labelPovzbuzujiciText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(185, 163);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 38);
            textBox1.TabIndex = 2;
            textBox1.Text = "ZDE NAPIŠ SVOJÍ PŘEZDÍVKU";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonHotovo
            // 
            buttonHotovo.DialogResult = DialogResult.OK;
            buttonHotovo.Location = new Point(291, 234);
            buttonHotovo.Name = "buttonHotovo";
            buttonHotovo.Size = new Size(94, 29);
            buttonHotovo.TabIndex = 3;
            buttonHotovo.Text = "hotovo";
            buttonHotovo.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 307);
            Controls.Add(buttonHotovo);
            Controls.Add(textBox1);
            Controls.Add(labelPovzbuzujiciText);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelPovzbuzujiciText;
        private TextBox textBox1;
        private Button buttonHotovo;
    }
}