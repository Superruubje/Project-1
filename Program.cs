namespace Kaart
{
    public interface ITekener
    {
        public void Teken(ConsoleTekener t);
    }

    public interface ITekenbaar{
        public void TekenConsole(ConsoleTekener t);
    }

    
    class Starter
    {
        public static void Main(string[] args)
        {
            Kaart k = new Kaart(30, 30);
            Pad p1 = new Pad();
            p1.van = new Coordinaat(2, 5);
            p1.naar = new Coordinaat(12, 30);
            k.VoegPadToe(p1);
            Pad p2 = new Pad();
            p2.van = new Coordinaat(26, 4);
            p2.naar = new Coordinaat(10, 5);
            k.VoegPadToe(p2);
            //k.VoegItemToe(new Attractie(k, new Coordinaat(15, 15)));
            //k.VoegItemToe(new Attractie(k, new Coordinaat(20, 15)));
            //k.VoegItemToe(new Attractie(k, new Coordinaat(5, 18)));
            k.Teken(new ConsoleTekener());
            new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.Hoogte + 1), "Deze kaart is schaal 1:1000");
            System.Console.Read();

        }
    }
   

    class Kaart : ITekener
    {   
        public List<KaartItem> Items = new List<KaartItem>();
        public List<Pad> Paden = new List<Pad>();
        public int Breedte;
        public int Hoogte;

        public Kaart(int breedte, int hoogte)
        {
            Breedte = breedte;
            Hoogte = hoogte;
        }

        public void VoegItemToe(KaartItem i)
        {
            Items.Add(i);
        }

        public void VoegPadToe(Pad p)
        {
            Paden.Add(p);
        }

        public void Teken(ConsoleTekener t)
        {
            foreach (Pad p in Paden)
            {
                p.TekenConsole(new ConsoleTekener());
            }

        }
    }

    public class ConsoleTekener : ITekener
    {
    
        public void SchrijfOp(Coordinaat Positie, string Text) {
            if (Positie.x < 0 || Positie.y < 0)
            throw new Exception("Kan niet tekenen in het negatieve!");
            Console.SetBufferSize(1920, 1080);
            Console.SetCursorPosition(Positie.x, Positie.y);
            Console.WriteLine(Text);
            Console.SetCursorPosition(0, 0);
        }
        public void Teken(ConsoleTekener t)
        {
            throw new NotImplementedException();
        }
    }


    class KaartItem : ITekenbaar
    {
        private Coordinaat _locatie;    //field
        public Coordinaat _Locatie      //property
        {
            get{return _locatie;}
            set{_locatie = value;}
        }

        public KaartItem(Kaart kaart, Coordinaat _Locatie)
        {
            
        }

        public void TekenConsole(ConsoleTekener t)
        {
            throw new NotImplementedException();
        }
    }
    
    class Pad : ITekenbaar
    {
        private float? lengteBerkend;

        public Coordinaat van { get; set; }
        public Coordinaat naar { get; set; }

        

        public float Lengte()
        {
            if (!lengteBerkend.HasValue)
            lengteBerkend = (float)Math.Sqrt((van.x - naar.x) * (van.x - naar.x) + (van.y - naar.y) * (van.y - naar.y));
            return lengteBerkend.Value;
        }
        public float Afstand(Coordinaat c)
        {
            c = van + naar;
            return 1.2F;
        }

        public void TekenConsole(ConsoleTekener t)
        {
            for (int i = 0; i < (int)Lengte(); i++)
            {
            float factor = i / Lengte();
            t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * factor), (int)Math.Round(van.y + (naar.y - van.y) * factor)), "#");
            }
            t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * .5), (int)Math.Round(van.y + (naar.y - van.y) * .5)), (1000 * Lengte()).MetSuffixen());
        }
    }

    /*class Attractie
    {
        string naam;

        public Attractie(Kaart k, Coordinaat coordinaat)
        {
        }
    } */

    public struct Coordinaat
    {
        public readonly int x;
        public readonly int y;

        public Coordinaat(int b, int h)
        {
            x = b;
            y = h;
        }

        public static Coordinaat operator +(Coordinaat x, Coordinaat y)
        {
            Coordinaat eind = new Coordinaat(x.x + y.x, x.y + y.y);
            return eind;
        }
        public static Coordinaat operator -(Coordinaat x, Coordinaat y)
        {
            Coordinaat eind = new Coordinaat(x.x - y.x, x.y - y.y);
            return eind;
        }
    }
    
    static class Float
    {
        public static string MetSuffixen(this float F)
        {
            if (F >= Math.Pow(10, 3) & F < Math.Pow(10, 6))
            {
                return (F / Math.Pow(10, 3) + "K").ToString();
            }
            else if (F >= Math.Pow(10, 6) & F < Math.Pow(10, 9))
            {
                return (F / Math.Pow(10, 6) + "K").ToString();
            }
            else if (F >= Math.Pow(10, 9))
            {
                return (F / Math.Pow(10, 9) + "K").ToString();
            }
            return F.ToString();
        }
    }

}

/*
namespace Authenticatie{
    
    class Gebruiker
    {
        public string Wachtwoord  // property
        { get; set; }
        public string Email  // property
        { get; set; }

        public Boolean Geverifieerd(){
            return true;
        }

    }

    class GebruikerContext
    {
        List<Gebruiker> gebruikers = new List<Gebruiker>;
        public int AantalGebruikers()
        {
            return 1; //tijdelijke value
        }
        public Gebruiker GetGebruiker(int i)
        {   
            gebruikers[i];
        }
        public void NieuweGebruiker(string Wachtwoord, string email)
        {
            Gebruiker myObj = new Gebruiker();
            myObj.Wachtwoord = Wachtwoord;
            myObj.Email = email;
            gebruikers.Add(myObj);
        }
    }

    class GebruikerService
    {
        public Gebruiker Registreer(string email, string Wachtwoord){
            
            EmailService.Email();
            //Registreer in GebruikerService: bij het registreren van een nieuwe Gebruiker,
            //moet er een email worden verstuurd ter verificatie, gebruikmakend van EmailService.
            //Er wordt een Gebruiker aangemaakt in de GebruikerContext.


        }
        public Boolean Login(string email, string wachtwoord){
        
            return true; //tijdelijke value
        }
        public Boolean Verifieer(string email, string token){
            return true; //tijdelijke value
        }
    }
    
    class EmailService
    {
        public void Email(string tekst, string naarAdres){

        }
    }

    class VerificatieToken
    {
        public string token  // property
        { get; set; }
        public DateTime VerloopDatum  // property
        { get; set; }
    }

    class Gast
    {
        public int Rating  // property
        { get; set; }
        public int Boete  // property
        { get; set; }
        public DateTime GeboorteDatum // property
        { get; set; }

        public void Bezoek(){

        }
        public void VIPBezoek(){

        }
        public void GeefStraf(string daden){

        }
        
    }
    
    class Planner
    {
            //implement later
    }

    class Medewerker
    {
            //implement later
    }
}
*/
