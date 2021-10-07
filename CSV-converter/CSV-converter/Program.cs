using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_converter
{
    class Program
    {
        #region Pokemon
        public enum PokemonType
        {
            None,
            Normal,
            Fire,
            Water,
            Electric,
            Grass,
            Ice,
            Fighting,
            Poison,
            Ground,
            Flying,
            Psychic,
            Bug,
            Rock,
            Ghost,
            Dragon,
            Dark,
            Steel,
            Fairy
        }

        public class PokemonCatchRate {
            private int pokedexNumber = 0;
            private string name = "";
            private int catchRate = 0;

            public PokemonCatchRate(int pokedexNumber, string name, int catchRate)
            {
                this.pokedexNumber = pokedexNumber;
                this.name = name;
                this.catchRate = catchRate;
            }

            public int PokedexNumber { get => pokedexNumber; set => pokedexNumber = value; }
            public string Name { get => name; set => name = value; }
            public int CatchRate { get => catchRate; set => catchRate = value; }
        }

        public class PokemonYeld
        {
            private int pokedexNumber = 0;
            private string name = "";
            private int expYeld = 0;

            public PokemonYeld(int pokedexNumber, string name, int expYeld)
            {
                this.pokedexNumber = pokedexNumber;
                this.name = name;
                this.expYeld = expYeld;
            }

            public int PokedexNumber { get => pokedexNumber; set => pokedexNumber = value; }
            public string Name { get => name; set => name = value; }
            public int ExpYeld { get => expYeld; set => expYeld = value; }
        }

        #endregion

        #region Move
        public enum MoveCategory
        {
            Physical, Special, Status
        }

        public enum MoveTarget
        {
            Foe, Self
        }

        #endregion


        static void Main(string[] args)
        {

            #region Pokemon
            List<PokemonCatchRate> pokemonCatchRates = new List<PokemonCatchRate>();
            List<PokemonYeld> pokemonYelds = new List<PokemonYeld>();

            int pokedexNumber = 0;
            string name = "ERROR";
            int type1 = 0;
            int type2 = 0;
            int hp = 0;
            int attack = 0;
            int defense = 0;
            int spAttack = 0;
            int spDefense = 0;
            int speed = 0;
            int expYeld = 0;
            int catchRate = 0;

            using (TextFieldParser parserCatchRate = new TextFieldParser(@"C:\Users\manud\Documents\GitHub\CSV-converter\CSVs\catchRate.csv"))

            {
                parserCatchRate.TextFieldType = FieldType.Delimited;
                parserCatchRate.SetDelimiters(",");
                while (!parserCatchRate.EndOfData)
                {
                    //Process row
                    string[] fields = parserCatchRate.ReadFields();
                    try {
                        pokemonCatchRates.Add(new PokemonCatchRate(Int32.Parse(fields[0]), fields[1], Int32.Parse(fields[2])));
                    }
                    catch { }
                }
            }

            using (TextFieldParser parserYeld = new TextFieldParser(@"C:\Users\manud\Documents\GitHub\CSV-converter\CSVs\yeld.csv"))

            {
                parserYeld.TextFieldType = FieldType.Delimited;
                parserYeld.SetDelimiters(",");
                while (!parserYeld.EndOfData)
                {
                    //Process row
                    string[] fields = parserYeld.ReadFields();
                    try
                    {
                        pokemonYelds.Add(new PokemonYeld(Int32.Parse(fields[0]), fields[1], Int32.Parse(fields[2])));
                    }
                    catch { }
                }
            }

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\manud\Documents\GitHub\CSV-converter\CSVs\pokemon.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        try
                        {
                            pokedexNumber = Int32.Parse(fields[0]);
                            name = fields[1];
                            type1 = (int)Enum.Parse(typeof(PokemonType), fields[2]);

                            if (fields[3] != null && fields[3] != "")
                                type2 = (int)Enum.Parse(typeof(PokemonType), fields[3]);
                            else
                                type2 = 0;

                            hp = Int32.Parse(fields[5]);
                            attack = Int32.Parse(fields[6]);
                            defense = Int32.Parse(fields[7]);
                            spAttack = Int32.Parse(fields[8]);
                            spDefense = Int32.Parse(fields[9]);
                            speed = Int32.Parse(fields[10]);
                            foreach (PokemonYeld pokemonYeld in pokemonYelds)
                            {
                                if (pokemonYeld.Name.Equals(name))
                                {
                                    expYeld = pokemonYeld.ExpYeld;
                                }
                            }
                            foreach (PokemonCatchRate pokemonCatchRate in pokemonCatchRates)
                            {
                                if (pokemonCatchRate.Name.Equals(name))
                                {
                                    catchRate = pokemonCatchRate.CatchRate;
                                }
                            }
                        }
                        catch
                        {

                        }

                        string path = @"C:\Users\manud\Documents\GitHub\CSV-converter\Assets\Pokemons\" + $"{pokedexNumber:D3}" + " " + name + ".asset";

                        if (!File.Exists(path))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine("%YAML 1.1");
                                sw.WriteLine("%TAG !u! tag:unity3d.com,2011:");
                                sw.WriteLine("--- !u!114 &11400000");
                                sw.WriteLine("MonoBehaviour:");
                                sw.WriteLine("  m_ObjectHideFlags: 0");
                                sw.WriteLine("  m_CorrespondingSourceObject: {fileID: 0}");
                                sw.WriteLine("  m_PrefabInstance: {fileID: 0}");
                                sw.WriteLine("  m_PrefabAsset: {fileID: 0}");
                                sw.WriteLine("  m_GameObject: {fileID: 0}");
                                sw.WriteLine("  m_Enabled: 1");
                                sw.WriteLine("  m_EditorHideFlags: 0");
                                sw.WriteLine("  m_Script: {fileID: 11500000, guid: e5aa4a7f37a22714c9924381e9ade610, type: 3}");
                                sw.WriteLine("  m_Name: " + $"{pokedexNumber:D3}");
                                sw.WriteLine("  m_EditorClassIdentifier: ");
                                sw.WriteLine("  name: " + name);
                                sw.WriteLine("  description: ");
                                sw.WriteLine("  frontSprite: ");
                                sw.WriteLine("  backSprite: ");
                                sw.WriteLine("  type1: " + type1);
                                sw.WriteLine("  type2: " + type2);
                                sw.WriteLine("  maxHp: " + hp);
                                sw.WriteLine("  attack: " + attack);
                                sw.WriteLine("  defense: " + defense);
                                sw.WriteLine("  spAttack: " + spAttack);
                                sw.WriteLine("  spDefense: " + spDefense);
                                sw.WriteLine("  speed: " + speed);
                                sw.WriteLine("  expYield: " + expYeld);
                                sw.WriteLine("  growthRate: 0");
                                sw.WriteLine("  catchRate: " + catchRate);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Move
            string nameMove = "ERROR";
             string descriptionMove = "ERROR DESCRIPTION";
             int typeMove = 0;
             int powerMove = 0;
             int accuracyMove = 0;
             bool alwaysHitsMove = false;
             int ppMove = 0;
             int priorityMove = 0;
             int categoryMove = 0;
             int targetMove = 0;

            using (TextFieldParser parserMove = new TextFieldParser(@"C:\Users\manud\Documents\GitHub\CSV-converter\CSVs\move.csv"))
            {
                parserMove.TextFieldType = FieldType.Delimited;
                parserMove.SetDelimiters(",");
                while (!parserMove.EndOfData)
                {
                    //Process row
                    string[] fields = parserMove.ReadFields();
                    foreach (string field in fields)
                    {
                        try
                        {
                            nameMove = fields[1].Trim(new Char[] { '*'});
     
                            typeMove = (int)Enum.Parse(typeof(PokemonType), fields[2]);
                            categoryMove = (int)Enum.Parse(typeof(MoveCategory), fields[3]);
                            ppMove = Int32.Parse(fields[5]);
                            powerMove = Int32.Parse(fields[6]);
                            accuracyMove = Int32.Parse(fields[7].Trim(new Char[] { '%' }));
                        }
                        catch
                        {

                        }

                        string path = @"C:\Users\manud\Documents\GitHub\CSV-converter\Assets\Moves\" + nameMove + ".asset";

                        if (!File.Exists(path))
                        {
                            // Create a file to write to.
                            using (StreamWriter swMove = File.CreateText(path))
                            {
                                swMove.WriteLine("%YAML 1.1");
                                swMove.WriteLine("%TAG !u! tag:unity3d.com,2011:");
                                swMove.WriteLine("--- !u!114 &11400000");
                                swMove.WriteLine("MonoBehaviour:");
                                swMove.WriteLine("  m_ObjectHideFlags: 0");
                                swMove.WriteLine("  m_CorrespondingSourceObject: {fileID: 0}");
                                swMove.WriteLine("  m_PrefabInstance: {fileID: 0}");
                                swMove.WriteLine("  m_PrefabAsset: {fileID: 0}");
                                swMove.WriteLine("  m_GameObject: {fileID: 0}");
                                swMove.WriteLine("  m_Enabled: 1");
                                swMove.WriteLine("  m_EditorHideFlags: 0");
                                swMove.WriteLine("  m_Script: {fileID: 11500000, guid: f75524a02c41cff4c8ed3d56e5257cba, type: 3}");
                                swMove.WriteLine("  m_Name: " + nameMove);
                                swMove.WriteLine("  m_EditorClassIdentifier: ");
                                swMove.WriteLine("  name: " + nameMove);
                                swMove.WriteLine("  description: ");
                                swMove.WriteLine("  type: " + typeMove);
                                swMove.WriteLine("  power: " + powerMove);
                                swMove.WriteLine("  accuracy: " + accuracyMove);
                                swMove.WriteLine("  alwaysHits: " + alwaysHitsMove);
                                swMove.WriteLine("  pp: " + ppMove);
                                swMove.WriteLine("  priority: " + priorityMove);
                                swMove.WriteLine("  category: " + categoryMove);
                                swMove.WriteLine("  effects: ");
                                swMove.WriteLine("  boosts: []");
                                swMove.WriteLine("  status: 0");
                                swMove.WriteLine("  volatileStatus: 0");
                                swMove.WriteLine("  target: " + targetMove);
                            }
                        }
                    }
                }
            }

            #endregion

        }
    }
}