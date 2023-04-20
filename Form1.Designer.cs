namespace DemoWordle
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
            this.buttonNou = new System.Windows.Forms.Button();
            this.textBoxParaula = new System.Windows.Forms.TextBox();
            this.labelMissatges = new System.Windows.Forms.Label();
            this.buttonPartida = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.buttonDEL = new System.Windows.Forms.Button();
            this.buttonCHECK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNou
            // 
            this.buttonNou.Location = new System.Drawing.Point(67, 19);
            this.buttonNou.Name = "buttonNou";
            this.buttonNou.Size = new System.Drawing.Size(75, 42);
            this.buttonNou.TabIndex = 5;
            this.buttonNou.Text = "Nova paraula";
            this.buttonNou.UseVisualStyleBackColor = true;
            this.buttonNou.Click += new System.EventHandler(this.buttonNou_Click);
            // 
            // textBoxParaula
            // 
            this.textBoxParaula.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxParaula.Location = new System.Drawing.Point(148, 19);
            this.textBoxParaula.Name = "textBoxParaula";
            this.textBoxParaula.Size = new System.Drawing.Size(94, 39);
            this.textBoxParaula.TabIndex = 6;
            this.textBoxParaula.Text = "XXXXX";
            this.textBoxParaula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxParaula.UseSystemPasswordChar = true;
            // 
            // labelMissatges
            // 
            this.labelMissatges.AutoSize = true;
            this.labelMissatges.Location = new System.Drawing.Point(12, 312);
            this.labelMissatges.Name = "labelMissatges";
            this.labelMissatges.Size = new System.Drawing.Size(59, 15);
            this.labelMissatges.TabIndex = 23;
            this.labelMissatges.Text = "missatges";
            // 
            // buttonPartida
            // 
            this.buttonPartida.Location = new System.Drawing.Point(248, 19);
            this.buttonPartida.Name = "buttonPartida";
            this.buttonPartida.Size = new System.Drawing.Size(75, 39);
            this.buttonPartida.TabIndex = 25;
            this.buttonPartida.Text = "Començar";
            this.buttonPartida.UseVisualStyleBackColor = true;
            this.buttonPartida.Click += new System.EventHandler(this.buttonPartida_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(12, 336);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(331, 130);
            this.pnlButtons.TabIndex = 28;
            // 
            // buttonDEL
            // 
            this.buttonDEL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDEL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDEL.Location = new System.Drawing.Point(349, 336);
            this.buttonDEL.Name = "buttonDEL";
            this.buttonDEL.Size = new System.Drawing.Size(65, 47);
            this.buttonDEL.TabIndex = 29;
            this.buttonDEL.Text = "⌫";
            this.buttonDEL.UseVisualStyleBackColor = true;
            this.buttonDEL.Click += new System.EventHandler(this.ClickDEL);
            // 
            // buttonCHECK
            // 
            this.buttonCHECK.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCHECK.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonCHECK.Location = new System.Drawing.Point(349, 400);
            this.buttonCHECK.Name = "buttonCHECK";
            this.buttonCHECK.Size = new System.Drawing.Size(65, 47);
            this.buttonCHECK.TabIndex = 30;
            this.buttonCHECK.Text = "✔";
            this.buttonCHECK.UseVisualStyleBackColor = true;
            this.buttonCHECK.Click += new System.EventHandler(this.ClickCHECK);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 94);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(398, 208);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 554);
            this.Controls.Add(this.buttonCHECK);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonDEL);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.buttonPartida);
            this.Controls.Add(this.labelMissatges);
            this.Controls.Add(this.textBoxParaula);
            this.Controls.Add(this.buttonNou);
            this.Name = "Form1";
            this.Text = "Demo Wordle";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonNou;
        private TextBox textBoxParaula;
        private Label labelMissatges;
        private Button buttonPartida;
        private Panel pnlButtons;
        private Button buttonDEL;
        private Button buttonCHECK;
        private DataGridView dataGridView1;
    }
}