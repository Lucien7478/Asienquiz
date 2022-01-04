namespace Asienquiz
{
  public class Land
  {
        //hinzufügen der Klassenvariablen
        private int landID;
        private string hauptstadt;
        private string land;

        //Konstruktor der Klasse - dieser initialisiert die Klassenvariablen mit den übergebenen Parametern
        public Land(int landID, string hauptstadt, string land)
        {
            this.landID = landID;
            this.hauptstadt = hauptstadt;
            this.land = land;
        }

        //gibt die LandID des erzeugten Objektes wieder
        public int getLandID()
        {
            return landID;
        }
        //gibt die Hauptstadt des erzeugten Objektes wieder
        public string getHauptstadt()
        {
             return hauptstadt;
        }
        //gibt das Land des erzeugten Objektes wieder
        public string getLand()
        {
            return land;
        }
  }
}
