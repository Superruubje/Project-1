namespace Kaart
{
    interface ITekener
    {
        public void Teken(ITekenbaar t);
    }

    interface ITekenbaar{
        public void TekenConsole(ConsoleTekener t);
    }

    
    class Starter
    {
        public static void Main(string[] args)
        {
            Kaart k = new Kaart(30, 30);
            Pad p = new Pad();
            p.van = new Coordinaat(2, 5);
            p.naar = new Coordinaat(12, 30);
            k.Teken(new ConsoleTekener());
        }
    }
   

    class Kaart : ITekener
    {
        public int Breedte;
        public int Hoogte;

        public Kaart(int breedte, int hoogte)
        {
            Breedte = breedte;
            Hoogte = hoogte;
        }

        public void Teken(ITekenbaar t)
        {

        }

        public void VoegItemToe()
        {

        }

        internal void Teken(ConsoleTekener consoleTekener)
        {
            throw new NotImplementedException();
        }
    }

    class ConsoleTekener : ITekener
    {
    
        public static void SchrijfOp(Coordinaat Positie, string Text)
        {
            if (Positie.x < 0 || Positie.y < 0)
            {

                Console.SetBufferSize(1920, 1080);
                Console.SetCursorPosition(Positie.x, Positie.y);
                Console.WriteLine(Text);
                throw new Exception("Kan niet tekenen in het negatieve!");

            }

        }
        public void Teken(ITekenbaar t)
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
        private float? LengteBerkend;

        public Coordinaat van;
        public Coordinaat naar;

        

        public float Lengte()
        {
            Coordinaat c = van + naar;
            return 1.1F;
        }
        public float Afstand(Coordinaat c)
        {
            return 1.2F;
        }

        public void TekenConsole(ConsoleTekener t)
        {
            Coordinaat verschil = naar - van;
            for (int i = 0; i < 100; i++)
            {
                ConsoleTekener.SchrijfOp(van + new Coordinaat((int)(verschil.x * ((float)i / 100)), (int)(verschil.y * ((float)i / 100))), "#");
            }
        }
    }
    

    struct Coordinaat
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

namespace Authenticatie{
    
    class Gebruiker
    {
        public string Wachtwoord  // property
        { get; set; }
        public string Name  // property
        { get; set; }
        public string Email  // property
        { get; set; }

        public Boolean Geverifieerd(){
            return true;
        }

    }

    class GebruikerContext
    {
        public int AantalGebruikers()
        {
            return 1; //tijdelijke value
        }
        public Gebruiker GetGebruiker(int i)
        {   
            
        }
        public void NieuweGebruiker(string Wachtwoord, string naam, string email)
        {
            
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