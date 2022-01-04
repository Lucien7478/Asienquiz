using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Asienquiz
{
    public class Form3 : Form
    {
        //hinzufügen der Klassenvariablen - sortiert nach Grafisch relevanten Klassenvariablen und Variablen zur Datenverwaltung innerhalb des Programmes
        //Datenverwaltung
        IContainer components = (IContainer) null;
        //grafische Steuerelemente
        private Label anzeigeGlueckwuensche;
        private Label anzeigePersoenlicherHighscore;
        private RadioButton anzeigePersoenlicherHighscoreBtn;
        private RichTextBox wertPersoenlicherHighscore;
        private Label anzeigeOeffentlicherHighscore;
        private RadioButton anzeigeOeffentlicherHighscoreBtn;
        private RichTextBox wertOeffentlicherHighscore;
        private Button wiederholen;

        public Form3()
        {
            initializeComponents();
        }

        //überschreibt die in Form deklarierte Dispose-Funktion und führt stattdessen diese aus
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void initializeComponents()
        {
            //unterbrechen des Layoutings
            SuspendLayout();

            //Überschrift erstellen, anpassen und hinzufügen
            anzeigeGlueckwuensche = new Label();
            anzeigeGlueckwuensche.Font = new Font("Microsoft YaHei", 21.75f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            anzeigeGlueckwuensche.Location = new Point(200, 35);
            anzeigeGlueckwuensche.Size = new Size(600, 80);
            anzeigeGlueckwuensche.Text = "Herzlichen Glückwunsch Sie haben das \r \n AsienQuiz absolviert.";
            add(anzeigeGlueckwuensche);

            //Label für die Anforderung der Anzeige des persönlichen Highscores erstellen, anpassen und hinzufügen
            anzeigePersoenlicherHighscore = new Label();
            anzeigePersoenlicherHighscore.Location = new Point(35, 225);
            anzeigePersoenlicherHighscore.Size = new Size(205, 15);
            anzeigePersoenlicherHighscore.Text = "Persönlichen Highscore anzeigen lassen:";
            add(anzeigePersoenlicherHighscore);

            //RadioButton für die Anforderung der Anzeige des persönlichen Highscores erstellen, anpassen und hinzufügen
            anzeigePersoenlicherHighscoreBtn = new RadioButton();
            anzeigePersoenlicherHighscoreBtn.Location = new Point(310, 225);
            anzeigePersoenlicherHighscoreBtn.Size = new Size(30, 20);
            anzeigePersoenlicherHighscoreBtn.Text = "1";
            anzeigePersoenlicherHighscoreBtn.UseVisualStyleBackColor = true;
            add(anzeigePersoenlicherHighscoreBtn);

            //RichTextBox, welche nach Implementierung den Wert aus der Datenbank erhält
            wertPersoenlicherHighscore = new RichTextBox();
            wertPersoenlicherHighscore.Location = new Point(437, 224);
            wertPersoenlicherHighscore.Size = new Size(190, 40);
            wertPersoenlicherHighscore.Text = "";
            add(wertPersoenlicherHighscore);

            //Label für die Anforderung der Anzeige des öffentlichen Highscores erstellen, anpassen und hinzufügen
            anzeigeOeffentlicherHighscore = new Label();
            anzeigeOeffentlicherHighscore.Location = new Point(35, 300);
            anzeigeOeffentlicherHighscore.Size = new Size(240, 15);
            anzeigeOeffentlicherHighscore.Text = "High-Score im Vergleich zu allen anzeigen lassen";
            add(anzeigeOeffentlicherHighscore);

            //RadioButton für die Anforderung der Anzeige des öffentlichen Highscores erstellen, anpassen und hinzufügen
            anzeigeOeffentlicherHighscoreBtn = new RadioButton();
            anzeigeOeffentlicherHighscoreBtn.Location = new Point(310, 300);
            anzeigeOeffentlicherHighscoreBtn.Size = new Size(30, 20);
            anzeigeOeffentlicherHighscoreBtn.Text = "2";
            anzeigeOeffentlicherHighscoreBtn.UseVisualStyleBackColor = true;
            add(anzeigeOeffentlicherHighscoreBtn);

            //RichTextBox, welche nach Implementierung den Wert aus der Datenbank erhält
            wertOeffentlicherHighscore = new RichTextBox();
            wertOeffentlicherHighscore.Location = new Point(440, 290);
            wertOeffentlicherHighscore.Size = new Size(190, 150);
            wertOeffentlicherHighscore.Text = "";
            add(wertOeffentlicherHighscore);

            //Button zum Wiederholen des Spieles erstellen, anpassen und hinzufügen
            wiederholen = new Button();
            wiederholen.Size = new Size(75, 25);
            wiederholen.Text = "Nochmal \r\n";
            wiederholen.UseVisualStyleBackColor = true;
            wiederholen.Click += new EventHandler(wiederholenClickEvent);
            add(wiederholen);

            //Dimensionen für das Steuerelement festlegen, den Skalierungsmodus festlegen, die Clientgröße bestimmen und den Text in der Taskleiste festlegen
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Abschluss-Fenster";

            //Unterbrockenes Layout fortsetzen
            ResumeLayout(false);
            PerformLayout();
        }

        //Einkürzung bzw. Vereinheitlichung zum hinzufügen eines Kontrollelementes zum Steuerelement
        private void add(Control control)
        {
            Controls.Add(control);
        }

        //Wiederholt das Spiel
        private void wiederholenClickEvent(Object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }
    }
}
