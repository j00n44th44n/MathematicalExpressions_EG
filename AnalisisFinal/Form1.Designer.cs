namespace AnalisisFinal
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbGrafico = new System.Windows.Forms.PictureBox();
            this.pbSerie = new System.Windows.Forms.PictureBox();
            this.pbDerivada = new System.Windows.Forms.PictureBox();
            this.pbIntegral = new System.Windows.Forms.PictureBox();
            this.input = new System.Windows.Forms.TextBox();
            this.tbSinceX = new System.Windows.Forms.TextBox();
            this.tbUntilX = new System.Windows.Forms.TextBox();
            this.tbSinceY = new System.Windows.Forms.TextBox();
            this.tbUntilY = new System.Windows.Forms.TextBox();
            this.enes = new System.Windows.Forms.RichTextBox();
            this.Ayuda = new System.Windows.Forms.PictureBox();
            this.Reiniciar = new System.Windows.Forms.PictureBox();
            this.Hecho = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDerivada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntegral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ayuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reiniciar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hecho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGrafico
            // 
            this.pbGrafico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbGrafico.BackgroundImage")));
            this.pbGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbGrafico.Location = new System.Drawing.Point(386, 202);
            this.pbGrafico.Name = "pbGrafico";
            this.pbGrafico.Size = new System.Drawing.Size(380, 332);
            this.pbGrafico.TabIndex = 0;
            this.pbGrafico.TabStop = false;
            this.toolTip1.SetToolTip(this.pbGrafico, "Serie");
            this.pbGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGrafico_Paint);
            this.pbGrafico.MouseEnter += new System.EventHandler(this.pbGrafico_MouseEnter);
            this.pbGrafico.MouseLeave += new System.EventHandler(this.pbGrafico_MouseLeave);
            // 
            // pbSerie
            // 
            this.pbSerie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSerie.BackgroundImage")));
            this.pbSerie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSerie.Location = new System.Drawing.Point(386, 42);
            this.pbSerie.Name = "pbSerie";
            this.pbSerie.Size = new System.Drawing.Size(380, 140);
            this.pbSerie.TabIndex = 0;
            this.pbSerie.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSerie, "Serie");
            this.pbSerie.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSerie_Paint);
            this.pbSerie.MouseEnter += new System.EventHandler(this.pbSerie_MouseEnter);
            this.pbSerie.MouseLeave += new System.EventHandler(this.pbSerie_MouseLeave);
            // 
            // pbDerivada
            // 
            this.pbDerivada.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDerivada.BackgroundImage")));
            this.pbDerivada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbDerivada.Location = new System.Drawing.Point(70, 179);
            this.pbDerivada.Name = "pbDerivada";
            this.pbDerivada.Size = new System.Drawing.Size(293, 143);
            this.pbDerivada.TabIndex = 0;
            this.pbDerivada.TabStop = false;
            this.toolTip1.SetToolTip(this.pbDerivada, "Derivada");
            this.pbDerivada.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDerivada_Paint);
            this.pbDerivada.MouseEnter += new System.EventHandler(this.pbDerivada_MouseEnter);
            this.pbDerivada.MouseLeave += new System.EventHandler(this.pbDerivada_MouseLeave);
            // 
            // pbIntegral
            // 
            this.pbIntegral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbIntegral.BackgroundImage")));
            this.pbIntegral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbIntegral.Location = new System.Drawing.Point(787, 179);
            this.pbIntegral.Name = "pbIntegral";
            this.pbIntegral.Size = new System.Drawing.Size(293, 141);
            this.pbIntegral.TabIndex = 0;
            this.pbIntegral.TabStop = false;
            this.toolTip1.SetToolTip(this.pbIntegral, "Integral");
            this.pbIntegral.Paint += new System.Windows.Forms.PaintEventHandler(this.pbIntegral_Paint);
            this.pbIntegral.MouseEnter += new System.EventHandler(this.pbIntegral_MouseEnter);
            this.pbIntegral.MouseLeave += new System.EventHandler(this.pbIntegral_MouseLeave);
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(246, 599);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(301, 31);
            this.input.TabIndex = 1;
            this.toolTip1.SetToolTip(this.input, "introduzca aqui la serie de pontencias");
            // 
            // tbSinceX
            // 
            this.tbSinceX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSinceX.Location = new System.Drawing.Point(566, 576);
            this.tbSinceX.Name = "tbSinceX";
            this.tbSinceX.Size = new System.Drawing.Size(45, 31);
            this.tbSinceX.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbSinceX, "inicio del intervalo X");
            // 
            // tbUntilX
            // 
            this.tbUntilX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUntilX.Location = new System.Drawing.Point(634, 576);
            this.tbUntilX.Name = "tbUntilX";
            this.tbUntilX.Size = new System.Drawing.Size(45, 31);
            this.tbUntilX.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbUntilX, "final del intervalo X");
            // 
            // tbSinceY
            // 
            this.tbSinceY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSinceY.Location = new System.Drawing.Point(566, 612);
            this.tbSinceY.Name = "tbSinceY";
            this.tbSinceY.Size = new System.Drawing.Size(45, 31);
            this.tbSinceY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbSinceY, "Inicio del Intervalo Y");
            // 
            // tbUntilY
            // 
            this.tbUntilY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUntilY.Location = new System.Drawing.Point(634, 612);
            this.tbUntilY.Name = "tbUntilY";
            this.tbUntilY.Size = new System.Drawing.Size(45, 31);
            this.tbUntilY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbUntilY, "Final del intervalo Y");
            // 
            // enes
            // 
            this.enes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enes.Location = new System.Drawing.Point(729, 581);
            this.enes.Name = "enes";
            this.enes.Size = new System.Drawing.Size(100, 57);
            this.enes.TabIndex = 2;
            this.enes.Text = "";
            // 
            // Ayuda
            // 
            this.Ayuda.BackColor = System.Drawing.Color.Black;
            this.Ayuda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ayuda.BackgroundImage")));
            this.Ayuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ayuda.Location = new System.Drawing.Point(835, 576);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(78, 63);
            this.Ayuda.TabIndex = 0;
            this.Ayuda.TabStop = false;
            this.toolTip1.SetToolTip(this.Ayuda, "Ayuda");
            this.Ayuda.Click += new System.EventHandler(this.ayuda_Click);
            this.Ayuda.MouseEnter += new System.EventHandler(this.Ayuda_MouseEnter);
            this.Ayuda.MouseLeave += new System.EventHandler(this.Ayuda_MouseLeave);
            // 
            // Reiniciar
            // 
            this.Reiniciar.BackColor = System.Drawing.Color.Black;
            this.Reiniciar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Reiniciar.BackgroundImage")));
            this.Reiniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Reiniciar.Location = new System.Drawing.Point(913, 577);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(76, 63);
            this.Reiniciar.TabIndex = 0;
            this.Reiniciar.TabStop = false;
            this.toolTip1.SetToolTip(this.Reiniciar, "Reiniciar");
            this.Reiniciar.Click += new System.EventHandler(this.restart_Click);
            this.Reiniciar.MouseEnter += new System.EventHandler(this.Reiniciar_MouseEnter);
            this.Reiniciar.MouseLeave += new System.EventHandler(this.Reiniciar_MouseLeave);
            // 
            // Hecho
            // 
            this.Hecho.BackColor = System.Drawing.Color.Black;
            this.Hecho.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hecho.BackgroundImage")));
            this.Hecho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Hecho.Location = new System.Drawing.Point(990, 578);
            this.Hecho.Name = "Hecho";
            this.Hecho.Size = new System.Drawing.Size(70, 61);
            this.Hecho.TabIndex = 0;
            this.Hecho.TabStop = false;
            this.toolTip1.SetToolTip(this.Hecho, "Graficar");
            this.Hecho.Click += new System.EventHandler(this.Done_Click);
            this.Hecho.MouseEnter += new System.EventHandler(this.Hecho_MouseEnter);
            this.Hecho.MouseLeave += new System.EventHandler(this.Hecho_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(176, 567);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(896, 82);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Rage Italic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(176, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 50);
            this.label2.TabIndex = 6;
            this.label2.Text = "An";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(614, 620);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(706, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "N";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(615, 585);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1175, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hecho);
            this.Controls.Add(this.enes);
            this.Controls.Add(this.tbUntilY);
            this.Controls.Add(this.tbSinceY);
            this.Controls.Add(this.tbUntilX);
            this.Controls.Add(this.tbSinceX);
            this.Controls.Add(this.input);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.Ayuda);
            this.Controls.Add(this.pbIntegral);
            this.Controls.Add(this.pbDerivada);
            this.Controls.Add(this.pbSerie);
            this.Controls.Add(this.pbGrafico);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1191, 700);
            this.MinimumSize = new System.Drawing.Size(1191, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDerivada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntegral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ayuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reiniciar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hecho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGrafico;
        private System.Windows.Forms.PictureBox pbSerie;
        private System.Windows.Forms.PictureBox pbDerivada;
        private System.Windows.Forms.PictureBox pbIntegral;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox tbSinceX;
        private System.Windows.Forms.TextBox tbUntilX;
        private System.Windows.Forms.TextBox tbSinceY;
        private System.Windows.Forms.TextBox tbUntilY;
        private System.Windows.Forms.RichTextBox enes;
        private System.Windows.Forms.PictureBox Ayuda;
        private System.Windows.Forms.PictureBox Reiniciar;
        private System.Windows.Forms.PictureBox Hecho;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

