namespace Asienquiz
{
    public class Spieler
    {
        //hinzufügen der Klassenvariablen
        private int spielerUuid;
        private int highscore;
        private string name;

        //Konstruktor der Klasse - dieser initialisiert die Klassenvariablen mit den übergebenen Parametern
        public Spieler(int sid, int hs, string n)
        {
            this.spielerUuid = sid;
            this.highscore = hs;
            this.name = n;
        }
        //gibt die SpielerUuid des erzeugten Objektes wieder
        public int getSpielerID()
        {
            return spielerUuid;
        }

        //gibt den Highscore des erzeugten Objektes wieder
        public int getHighscore()
        {
            return highscore;
        }

        //gibt den Namen des erzeugten Objektes wieder
        public string getName()
        {
            return name;
        }
    }
}
