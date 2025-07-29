namespace ProjectBD
{
    partial class FormCancion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.chkEsSencillo = new System.Windows.Forms.CheckBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.cmbAlbum = new System.Windows.Forms.ComboBox();
            this.lblArtistaPrincipal = new System.Windows.Forms.Label();
            this.cmbArtistaPrincipal = new System.Windows.Forms.ComboBox();
            this.btnGuardarCancion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(150, 27);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(250, 22);
            this.txtTitulo.TabIndex = 1;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(30, 70);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 16);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(150, 67);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 22);
            this.txtPrecio.TabIndex = 3;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(30, 110);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(64, 16);
            this.lblDuracion.TabIndex = 4;
            this.lblDuracion.Text = "Duración:";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(150, 107);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(100, 22);
            this.txtDuracion.TabIndex = 5;
            this.txtDuracion.Text = "HH:MM:SS";
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(30, 150);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(60, 16);
            this.lblFormato.TabIndex = 6;
            this.lblFormato.Text = "Formato:";
            // 
            // cmbFormato
            // 
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Items.AddRange(new object[] { "MP3", "WAV", "FLAC", "AAC" });
            this.cmbFormato.Location = new System.Drawing.Point(150, 147);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(121, 24);
            this.cmbFormato.TabIndex = 7;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(30, 190);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(57, 16);
            this.lblGenero.TabIndex = 8;
            this.lblGenero.Text = "Género:";
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(150, 187);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(250, 22);
            this.txtGenero.TabIndex = 9;
            // 
            // chkEsSencillo
            // 
            this.chkEsSencillo.AutoSize = true;
            this.chkEsSencillo.Location = new System.Drawing.Point(30, 230);
            this.chkEsSencillo.Name = "chkEsSencillo";
            this.chkEsSencillo.Size = new System.Drawing.Size(97, 20);
            this.chkEsSencillo.TabIndex = 10;
            this.chkEsSencillo.Text = "Es Sencillo";
            this.chkEsSencillo.UseVisualStyleBackColor = true;
            this.chkEsSencillo.CheckedChanged += new System.EventHandler(this.chkEsSencillo_CheckedChanged);
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(30, 270);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(48, 16);
            this.lblAlbum.TabIndex = 11;
            this.lblAlbum.Text = "Álbum:";
            // 
            // cmbAlbum
            // 
            this.cmbAlbum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlbum.FormattingEnabled = true;
            this.cmbAlbum.Location = new System.Drawing.Point(150, 267);
            this.cmbAlbum.Name = "cmbAlbum";
            this.cmbAlbum.Size = new System.Drawing.Size(250, 24);
            this.cmbAlbum.TabIndex = 12;
            // 
            // lblArtistaPrincipal
            // 
            this.lblArtistaPrincipal.AutoSize = true;
            this.lblArtistaPrincipal.Location = new System.Drawing.Point(30, 310);
            this.lblArtistaPrincipal.Name = "lblArtistaPrincipal";
            this.lblArtistaPrincipal.Size = new System.Drawing.Size(106, 16);
            this.lblArtistaPrincipal.TabIndex = 13;
            this.lblArtistaPrincipal.Text = "Artista Principal:";
            // 
            // cmbArtistaPrincipal
            // 
            this.cmbArtistaPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtistaPrincipal.FormattingEnabled = true;
            this.cmbArtistaPrincipal.Location = new System.Drawing.Point(150, 307);
            this.cmbArtistaPrincipal.Name = "cmbArtistaPrincipal";
            this.cmbArtistaPrincipal.Size = new System.Drawing.Size(250, 24);
            this.cmbArtistaPrincipal.TabIndex = 14;
            // 
            // btnGuardarCancion
            // 
            this.btnGuardarCancion.Location = new System.Drawing.Point(170, 360);
            this.btnGuardarCancion.Name = "btnGuardarCancion";
            this.btnGuardarCancion.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarCancion.TabIndex = 15;
            this.btnGuardarCancion.Text = "Guardar";
            this.btnGuardarCancion.UseVisualStyleBackColor = true;
            this.btnGuardarCancion.Click += new System.EventHandler(this.btnGuardarCancion_Click);
            // 
            // FormCancion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 420);
            this.Controls.Add(this.btnGuardarCancion);
            this.Controls.Add(this.cmbArtistaPrincipal);
            this.Controls.Add(this.lblArtistaPrincipal);
            this.Controls.Add(this.cmbAlbum);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.chkEsSencillo);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cmbFormato);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormCancion";
            this.Text = "Agregar Canción";
            this.Load += new System.EventHandler(this.FormCancion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.ComboBox cmbFormato;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.CheckBox chkEsSencillo;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.ComboBox cmbAlbum;
        private System.Windows.Forms.Label lblArtistaPrincipal;
        private System.Windows.Forms.ComboBox cmbArtistaPrincipal;
        private System.Windows.Forms.Button btnGuardarCancion;
    }
}
