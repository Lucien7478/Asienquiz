using Asienquiz.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Asienquiz
{
  public class Form1 : Form
  {
        //hinzufügen der Klassenvariablen - sortiert nach Grafisch relevanten Klassenvariablen und Variablen zur Datenverwaltung innerhalb des Programmes
        //Datenverwaltung
        private readonly DB datenbank = new DB();
        private readonly IContainer components = (IContainer)null;
        private Spieler sp;

        //grafische Steuerelemente
        private PictureBox asienKarte;
        private Label ueberschrift;
        private Label aufforderung;
        private ComboBox auswahlMoeglichkeiten;
        private Label nameUeberschrift;
        private TextBox nameBox;
        private Button start;
        private Button abbrechen;

        public Form1()
        {
            initializeComponent();
        }

        //überschreibt die in Form deklarierte Dispose-Funktion und führt stattdessen diese aus
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void initializeComponent()
        {
            //unterbrechen des Layoutings
            SuspendLayout();

            //Asienkarte erstellen, anpassen, Initialisierung beginnen und hinzufügen
            asienKarte = new PictureBox();
            ((ISupportInitialize)asienKarte).BeginInit();
            asienKarte.Image = (Image)Resources.Asien_Karte;
            asienKarte.Location = new Point(471, 12);
            asienKarte.Size = new Size(317, 272);
            asienKarte.SizeMode = PictureBoxSizeMode.Zoom;
            add(asienKarte);

            //Überschrift erstellen, anpassen und hinzufügen
            ueberschrift = new Label();
            ueberschrift.Text = "Asien Quiz";
            ueberschrift.Location = new Point((int) sbyte.MaxValue, 63);
            ueberschrift.AutoSize = true;
            ueberschrift.Font = new Font("Microsoft YaHei UI", 36f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            ueberschrift.Size = new Size(284, 64);
            add(ueberschrift);

            //Aufforderung zum auswählen einer Kategorie erstellen, anpassen und hinzufügen
            aufforderung = new Label();
            aufforderung.Text = "Bitte wählen Sie eine Kategorie aus";
            aufforderung.Location = new Point(77, 203);
            aufforderung.Size = new Size(175, 20);
            add(aufforderung);

            //Mögliche spielbare Modis zum auswählen als Combobox erstellen, anpassen und hinzufügen
            auswahlMoeglichkeiten = new ComboBox();
            auswahlMoeglichkeiten.Items.AddRange(new object[6]
            {
                (object) "Hauptstadt zu Land",
                (object) "Land zu Hauptstadt",
                (object) "Flagge zu Land ",
                (object) "Land zu Flagge ",
                (object) "Hauptstadt zu Flagge ",
                (object) "Flagge zu Hauptstadt"
            });
            auswahlMoeglichkeiten.Location = new Point(290, 200);
            auswahlMoeglichkeiten.Size = new Size(121, 21);
            auswahlMoeglichkeiten.SelectedIndexChanged += new EventHandler(this.auswahlMoeglichkeitenSelectedIndexChanged);
            add(auswahlMoeglichkeiten);

            //Aufforderung zum eingeben des Namens erstellen, anpassen und hinzufügen
            nameUeberschrift = new Label();
            nameUeberschrift.Text = "Bitte geben Sie ihren Namen ein";
            nameUeberschrift.Location = new Point(77, 350);
            nameUeberschrift.Size = new Size(175, 20);
            add(nameUeberschrift);

            //Eingabemöglichkeit für den Namen erstellen, anpassen und hinzufügen
            nameBox = new TextBox();
            nameBox.Location = new Point(290, 350);
            nameBox.Size = new Size(179, 20);
            add(nameBox);

            //Button zum beginnen des Spiels
            start = new Button();
            start.Location = new Point(518, 347);
            start.Size = new Size(75, 23);
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += new EventHandler(this.startClickEvent);
            add(start);

            //Button zum Abbrechen des Spiels bzw. zum beenden des Programmes
            abbrechen = new Button();
            abbrechen.Location = new Point(675, 347);
            abbrechen.Size = new Size(75, 23);
            abbrechen.Text = "Abbrechen";
            abbrechen.UseVisualStyleBackColor = true;
            abbrechen.Click += new EventHandler(this.abbrechenClickEvent);
            add(abbrechen);

            //Dimensionen für das Steuerelement festlegen, den Skalierungsmodus festlegen, die Clientgröße bestimmen und den Text in der Taskleiste festlegen
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Start-Fenster";
            //Initialisierung der Picturebox Asienkarte abschließen
            ((ISupportInitialize)asienKarte).EndInit();

            //Unterbrockenes Layout fortsetzen
            ResumeLayout(false);
            PerformLayout();
        }

        //Einkürzung bzw. Vereinheitlichung zum hinzufügen eines Kontrollelementes zum Steuerelement
        private void add(Control control)
        {
            Controls.Add(control);
        }

        //Signalisiert der Combobox, dass keine Aktion ausgeführt wird
        //Sollte dennoch eine Aktion in späteren Patches gewünscht sein, dann kann diese hier implementiert bzw. aufgerufen werden.
        private void auswahlMoeglichkeitenSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //ClickEvent für den Button, welcher das Spiel beginnen soll
        private void startClickEvent(object sender, EventArgs e)
        {
            sp = new Spieler(-1, -1, this.nameBox.Text);
            datenbank.saveSpieler(this.sp);
            new Form2(auswahlMoeglichkeiten.SelectedIndex).ShowDialog();
            Dispose();
        }

        //ClickEvent für den Button, welcher das Spiel beenden soll
        private void abbrechenClickEvent(object sender, EventArgs e)
        {
            Close();
        }
  }
}

