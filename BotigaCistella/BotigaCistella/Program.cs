using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Botiga
{
    internal class Program
    {
        public static class Variables
        {
            /// Títol de l'aplicació.
            public static string appTitol = "Botiga Cistella";
            /// Color primari de l'aplicació.
            public const ConsoleColor colorPrimari = ConsoleColor.White;
            /// Color secundari de l'aplicació.
            public const ConsoleColor colorSecundari = ConsoleColor.Green;
            /// Productes de la botiga.
            public static string[] productes = new string[10];
            // Preus dels productes.  
            public static double[] preus = new double[10];
            // Stock dels productes.  
            public static int[] quantitats = new int[10];
            // Número de productes.
            public static int numProductes = 0;

            // Productes cistella
            public static string[] productesCistella = new string[10];
            // Preus totals cistella
            public static double[] preusTotalsCistella = new double[10];
            // Quantitats comprades cistella
            public static int[] quantitatsCistella = new int[10];
            // Número de productes cistella.
            public static int numProductesCistella = 0;
            // Diners cistella
            public static double dinersDisponibles = 500;
        }

        public static void Main(string[] args)
        {
            // Comença amb el menú de la botiga per defecte. 
            BotigaMenu();
            // Input del menú (0 - Botiga | 1 - Cistella).
            DemanarInput(0);
        }

        /* 
         * =====================
         * =      BOTIGA       =
         * =====================
         */
        public static void BotigaMenu()
        {
            CentrarText("Botiga", Variables.colorSecundari);
            CentrarText("La teva botiga de confiança\n");
            CentrarText("╔══════════════════════════╗");
            CentrarText("║ (1) Afegir productes     ║");
            CentrarText("║ (2) Eliminar productes   ║");
            CentrarText("║ (3) Modificar productes  ║");
            CentrarText("║ (4) Mostrar productes    ║");
            CentrarText("║ (0) Anar a cistella      ║");
            CentrarText("║ (Q/q) Sortir             ║");
            CentrarText("╚══════════════════════════╝");
            Console.Write("\n");
        }

        public static void DemanarInput(int menu)
        {
            string opcio;
            bool acabat = false;
            if (menu == 0)
            {
                while (!acabat)
                {
                    CentrarText("Selecciona una opció: ", novaLinia: false);
                    opcio = Console.ReadLine();
                    switch (opcio)
                    {
                        // Sortir programa
                        case "q": CentrarText("Adéu!", Variables.colorSecundari); acabat = true; break;
                        case "Q": CentrarText("Adéu!", Variables.colorSecundari); acabat = true; break;

                        // Demanar producte
                        case "1": DemanarProducte(); Console.Clear(); BotigaMenu(); break;

                        // Eliminar producte
                        case "2": EliminarProducte(); Console.Clear(); BotigaMenu(); break;

                        // Modificar producte
                        case "3": InputModificacions(); Console.Clear(); BotigaMenu(); break;

                        // Mostrar productes
                        case "4": MostrarProductes(); Console.Clear(); BotigaMenu(); break;

                        // Ampliar botiga
                        case "5": MostrarProductes(); Console.Clear(); BotigaMenu(); break;

                        // Anar a cistella
                        case "0": Console.Clear(); CistellaMenu(); acabat = true; DemanarInput(1); break;

                        default: Console.Clear(); BotigaMenu(); break;
                    }
                }
            }
            else
            {
                while (!acabat)
                {
                    CentrarText("Selecciona una opció: ", novaLinia: false);
                    opcio = Console.ReadLine();
                    switch (opcio)
                    {
                        // Sortir programa
                        case "q": CentrarText("Adéu!", Variables.colorSecundari); acabat = true; break;
                        case "Q": CentrarText("Adéu!", Variables.colorSecundari); acabat = true; break;

                        // Comprar producte
                        case "1": ComprarProducte(); Console.Clear(); CistellaMenu(); break;

                        // Ordenar cistella
                        case "2": OrdenarCistella(); Console.Clear(); CistellaMenu(); break;

                        // Mostrar cistella
                        case "3": MostrarCistella(); Console.Clear(); CistellaMenu(); break;

                        // Anar a botiga
                        case "0": Console.Clear(); BotigaMenu(); acabat = true; DemanarInput(0); break;

                        default: Console.Clear(); CistellaMenu(); break;
                    }
                }
            }
        }

        public static void DemanarProducte()
        {
            string producte;
            int quantitat;
            double preu;

            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            CentrarText("Nou producte");

            Console.Write("Producte: "); producte = Console.ReadLine();
            Console.Write("Preu: €"); preu = Convert.ToDouble(Console.ReadLine());
            Console.Write("Quantitat: "); quantitat = Convert.ToInt32(Console.ReadLine());

            // Comprovar si no excedim el màxim de la capacitat de la botiga.
            if (Variables.numProductes != Variables.productes.Length) AfegirProducte(producte, preu, quantitat);
            else
            {
                string opcio;
                Console.Write("\nLa botiga està plena! Vols ampliar-la? (S/n) ");
                opcio = Console.ReadLine();
                if (opcio == "S" || opcio == "s" || opcio == "") AmpliarBotiga();
            }
        }

        public static void AfegirProducte(string producte, double preu, int quantitat)
        {
            Variables.productes[Variables.numProductes] = producte;
            Variables.preus[Variables.numProductes] = preu;
            Variables.quantitats[Variables.numProductes] = quantitat;
            Variables.numProductes += 1;
        }

        public static void InputModificacions()
        {
            string valor;
            string nouValor;
            string numTaula;

            Console.Clear();
            CentrarText("Modificar un producte");

            Console.WriteLine("|0. Modificar nom del producte\n|1. Modificar preu del producte\n|2. Modificar quantitat del producte\n");
            Console.Write("Indica que vols modificar: ");
            numTaula = Console.ReadLine();

            switch (numTaula)
            {
                case "0":
                    Console.Clear();
                    CentrarText("Modificar nom producte");
                    Console.Write("Indica el producte a modificar: "); valor = Console.ReadLine();
                    Console.Write("Indica el nou nom del producte: "); nouValor = Console.ReadLine();
                    ModificarProducte(valor, nouValor, numTaula);
                    break;

                case "1":
                    Console.Clear();
                    CentrarText("Modificar preu producte");
                    Console.Write("Indica el producte a modificar: "); valor = Console.ReadLine();
                    Console.Write("Indica el nou preu del producte: "); nouValor = Console.ReadLine();
                    ModificarProducte(valor, nouValor, numTaula);
                    break;

                case "2":
                    Console.Clear();
                    CentrarText("Modificar quantitat producte");
                    Console.Write("Indica el producte a modificar: "); valor = Console.ReadLine();
                    Console.Write("Indica la nova quantitat del producte: "); nouValor = Console.ReadLine();
                    ModificarProducte(valor, nouValor, numTaula);
                    break;

                default: Console.Clear(); InputModificacions(); break;
            }
        }

        public static void ModificarProducte(string valor, string nouValor, string taula)
        {
            int index = 0;
            string anticValor;
            bool trobat = false;

            // Busca el producte.
            for (int i = 0; i < Variables.productes.Length; i++)
                if (Variables.productes[i] == valor) { index = i; trobat = true; }

            if (trobat)
            {
                switch (taula)
                {
                    // Modificar taula productes
                    case "0":
                        anticValor = Variables.productes[index];
                        Variables.productes[index] = nouValor;
                        Console.WriteLine($"\nNom canviat: ({anticValor}) ==> ({nouValor})\n"); break;

                    // Modificar taula preus
                    case "1":
                        anticValor = Convert.ToString(Variables.preus[index]);
                        Variables.preus[index] = Convert.ToDouble(nouValor);
                        Console.WriteLine($"Preu canviat: ({anticValor}) ==> ({nouValor})"); break;

                    // Modificar taula quantitats
                    case "2":
                        anticValor = Convert.ToString(Variables.quantitats[index]);
                        Variables.quantitats[index] = Convert.ToInt32(nouValor);
                        Console.WriteLine($"Quantitat canviada: ({anticValor}) ==> ({nouValor})"); break;
                }
            }
            else Console.WriteLine("No s'ha trobat el producte que vols modificar o no existeix.\n");
            Esperar();
        }

        public static void EliminarProducte()
        {
            string producte;
            bool trobat = false;
            int index = 0;

            Console.Clear();
            CentrarText("Eliminar producte\n");
            Console.Write("Escriu el nom del producte que vulguis eliminar: "); producte = Console.ReadLine();
            for (int i = 0; i < Variables.productes.Length; i++)
                if (Variables.productes[i] == producte) { index = i; trobat = true; }

            if (trobat)
            {
                Variables.productes[index] = "";
                Variables.preus[index] = 0;
                Variables.quantitats[index] = 0;
                Variables.numProductes -= 1;
                Console.WriteLine($"S'ha eliminat el producte {producte} correctament.\n");
                Esperar();
            }
            else Console.WriteLine("No s'ha trobat el producte que vols eliminar o no existeix.\n");
            Esperar();
        }

        public static void OrdenarProductes()
        {
            Array.Sort(Variables.productes);
        }

        public static void OrdenarPreus()
        {
            Array.Sort(Variables.preus);
        }

        public static void MostrarProductes()
        {
            string[] productes = Variables.productes;
            double[] preus = Variables.preus;
            int[] quantitats = Variables.quantitats;

            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            CentrarText("Llistat de productes\n");

            if (Variables.numProductes > 0)
            {
                Console.WriteLine("Producte | Preu | Quantitat");
                for (int i = 0; i < Variables.productes.Length; i++)
                    if (productes[i] != "" && preus[i] != 0 && quantitats[i] != 0)
                        Console.WriteLine($"{productes[i]}, {preus[i]}€, {quantitats[i]}");
                Console.Write("\n");
            }
            else Console.WriteLine("Encara no has registrat cap producte.\n"); Esperar();
        }

        public static void AmpliarBotiga()
        {
            int ampliacio;

            Console.Clear();
            CentrarText("Ampliar botiga\n");

            Console.Write("Escriu quants espais vols ampliar la botiga: ");
            ampliacio = Convert.ToInt32(Console.ReadLine());

            Array.Resize(ref Variables.productes, Variables.productes.Length + ampliacio);
            Array.Resize(ref Variables.preus, Variables.preus.Length + ampliacio);
            Array.Resize(ref Variables.quantitats, Variables.quantitats.Length + ampliacio);

            Console.WriteLine($"\nBotiga ampliada {ampliacio} espai/s.\n");
            Esperar();
        }

        /* 
         * =====================
         * =     CISTELLA      =
         * =====================
         */
        public static void CistellaMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CentrarText("Cistella", Variables.colorSecundari);
            CentrarText("La teva cistella de la compra\n");
            CentrarText("╔══════════════════════════╗");
            CentrarText("║ (1) Comprar productes    ║");
            CentrarText("║ (2) Ordenar cistella     ║");
            CentrarText("║ (3) Mostrar cistella     ║");
            CentrarText("║ (0) Anar a botiga        ║");
            CentrarText("║ (Q/q) Sortir             ║");
            CentrarText("╚══════════════════════════╝");
            Console.Write("\n");
            CentrarText($"Diners disponibles: ({Variables.dinersDisponibles}€)\n");
        }

        public static void ComprarProducte()
        {
            string producte;
            int quantitat;
            int index = 0;
            double preuTotal;
            bool trobat = false;

            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            CentrarText("Comprar producte\n");
            Console.Write("Escriu el nom del producte que vulguis comprar: "); producte = Console.ReadLine();
            Console.Write("Escriu la quantitat que vulguis comprar: "); quantitat = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Variables.productes.Length; i++)
                if (Variables.productes[i] == producte) { index = i; trobat = true; }

            // Comprovar si la cistella està plena.
            if (Variables.numProductesCistella != Variables.productesCistella.Length)
            {
                // Si s'ha trobat i la quantitat desitjada no supera el stock disponible.
                if (trobat)
                {
                    if (quantitat <= Variables.quantitats[index])
                    {
                        // Agafar el valor total (preu * quantitat).
                        preuTotal = Variables.preus[index] * quantitat;
                        if (Variables.dinersDisponibles >= preuTotal)
                        {
                            // Resta el valor del producte als diners disponibles.
                            Variables.dinersDisponibles -= preuTotal;
                            // Afegeix el producte a la cistella i suma +1 al contador.
                            Variables.productesCistella[Variables.numProductesCistella] = Variables.productes[index];
                            // Guardar les quantitats i preus totals per després mostrar.
                            Variables.preusTotalsCistella[Variables.numProductesCistella] = preuTotal;
                            Variables.quantitatsCistella[Variables.numProductesCistella] = quantitat;
                            Variables.quantitats[index] -= quantitat;
                            Console.WriteLine($"\nProducte: {producte} comprat. | ({preuTotal}€) *{quantitat}\n");
                            // Per últim restar quantitat desitjada de l'stock
                            Variables.numProductesCistella += 1;
                        }
                        else
                        {
                            string opcio;
                            Console.WriteLine($"\nNo es pot comprar (*{quantitat} - {producte}) perquè no tens diners suficients {Variables.dinersDisponibles}€/{Variables.preus[index]}€\n");
                            Console.Write("\nVols afegir diners= (S/n)");
                            opcio = Console.ReadLine();
                            if (opcio == "S" || opcio == "s" || opcio == "") AfegirDiners();
                        }
                    }
                    else Console.WriteLine($"\nNo es pot comprar (*{quantitat} - {producte}) perquè l'stock és de {Variables.quantitats[index]}\n");
                }
                else Console.WriteLine("\nEl producte no s'ha trobat.\n");
            }
            else AmpliarCistella();
            Esperar();
        }

        public static void OrdenarCistella()
        {
            Array.Sort(Variables.productesCistella);
        }

        public static void MostrarCistella()
        {
            string[] productes = Variables.productesCistella;
            double[] preus = Variables.preusTotalsCistella;
            int[] quantitats = Variables.quantitatsCistella;

            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            CentrarText("Llistat de productes\n");

            if (Variables.numProductes > 0)
            {
                Console.WriteLine("Producte  | Quantitat | Preu total");
                for (int i = 0; i < Variables.productesCistella.Length; i++)
                    if (productes[i] != "" && preus[i] != 0 && quantitats[i] != 0)
                        Console.WriteLine($"{productes[i]}, {quantitats[i]}, {preus[i]}€");
                Console.Write("\n");
            }
            else Console.WriteLine("Encara no has comprat cap producte.\n");
            Esperar();
        }

        public static void AmpliarCistella()
        {
            int ampliacio;

            Console.Clear();
            CentrarText("Ampliar cistella\n");

            Console.Write("Escriu quants espais vols ampliar la teva cistella: ");
            ampliacio = Convert.ToInt32(Console.ReadLine());

            Array.Resize(ref Variables.productesCistella, Variables.productesCistella.Length + ampliacio);
            Array.Resize(ref Variables.preusTotalsCistella, Variables.preusTotalsCistella.Length + ampliacio);
            Array.Resize(ref Variables.quantitatsCistella, Variables.quantitatsCistella.Length + ampliacio);

            Console.WriteLine($"\nCistella ampliada {ampliacio} espai/s.\n");
            Esperar();
        }

        public static void AfegirDiners()
        {
            double diners;
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            CentrarText("Afegir diners\n");
            Console.Write("Escriu quants diners vols afegir: ");
            diners = Convert.ToDouble(Console.ReadLine());
            Variables.dinersDisponibles += diners;
            Console.WriteLine($"\n{diners}€ afegits correctament ara tens: {Variables.dinersDisponibles}€");
            Esperar();
        }

        /* 
        * =================
        * = MÈTODES ÚTILS =
        * =================
        */

        // Mètode per centrar el text que vulguis.
        public static void CentrarText(string txt, ConsoleColor color = Variables.colorPrimari, bool novaLinia = true)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, Console.CursorTop);
            if (novaLinia) Console.WriteLine(txt);
            else Console.Write(txt);
            Console.ResetColor();
        }

        // Mètode per esperar després d'un event o modificació. Per defecte 5 segons.
        public static void Esperar(int milisegons = 5000)
        {
            for (int i = milisegons / 1000; i != 0; i--)
            {
                Console.Write($"\rTornant al menú en: [{i}]");
                Thread.Sleep(1000);
            }
        }
    }
}
